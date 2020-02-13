using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Cryptology;
using Entities.Concrete;
using Entities.Dto;
using MailSync;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserPasswordChangeService _userPasswordChangeService;
        public AuthController(IAuthService authService, IUserService userService, 
            IUserPasswordChangeService userPasswordChangeService)
        {
            _authService = authService;
            _userService = userService;
            _userPasswordChangeService = userPasswordChangeService;
        }

        [Route("Giris")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [Route("Giris")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.CustomerUserLogin(userForLoginDto);
            if (!userToLogin.Success)
            {
                return View(userToLogin.Data);
            }

            await SignInAsync(userToLogin.Data);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInAsync(User user)
        {
            var claims = SetClaims(user, _userService.GetRoles(user));

            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(principal, authProperties);
        }

        private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(roles.Select(c => c.Name).ToArray());

            return claims;
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

        [Route("AdminGiris")]
        public IActionResult AdminLogin()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [Route("AdminGiris")]
        public async Task<IActionResult> AdminLogin(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.FTSUserLogin(userForLoginDto);
            if (!userToLogin.Success)
            {
                return View(userToLogin.Data);
            }

            await SignInAsync(userToLogin.Data);
            return RedirectToAction("Index", "Home");
        }

        [Route("SifreDegistir")]
        public IActionResult ResetPassword(string email = null,string message = null)
        {
            ViewBag.Message = message;
            ViewBag.Email = email;
            return View();
        }

        [HttpPost]
        [Route("SifreDegistir")]
        public IActionResult ResetPassword(PasswordChangeViewModel model)
        {
            if (model.Email == null)
            {
                return RedirectToAction("ResetPassword", new { message = "Email girilmedi" });
            }

            var user = _userService.GetByMail(model.Email);
            if (user == null)
            {
                return RedirectToAction("ResetPassword", new { email = model.Email, message = "Email sistemde kayıtlı değil." });
            }
            _userPasswordChangeService.AddByUser(user);
            return RedirectToAction("StartResetPassword", model);
        }

        public IActionResult StartResetPassword(PasswordChangeViewModel model)
        {
            return View(model);
        }


        public IActionResult ChangePassword(string passwordtoken)
        {
            var instance = _userPasswordChangeService.GetById(Convert.ToInt32(Cryptology.Decrypt(passwordtoken)));
            if (instance != null && instance.Status == false)
            {
                var model = new UserForChangePassword
                {
                    Id = instance.Id,
                    Email = _userService.GetById(instance.UserId).Email,
                    NewPassword = "",
                    NewPasswordAgain = ""
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult ChangePassword(UserForChangePassword userForChangePassword)
        {
            if(userForChangePassword.NewPassword != userForChangePassword.NewPasswordAgain)
            {
                return RedirectToAction("ChangePassword", new { passwordtoken = 
                            Cryptology.Encrypt(userForChangePassword.Id.ToString()) });
            }

            var changePassword = _userPasswordChangeService.GetById(userForChangePassword.Id);
            changePassword.Date = DateTime.Now;
            changePassword.Status = true;
            _userPasswordChangeService.Update(changePassword);

            var user = _userService.GetById(changePassword.UserId);
            user.Password = userForChangePassword.NewPassword;
            _userService.Update(user);

            return RedirectToAction("Login", "Auth");
        }

    }
}