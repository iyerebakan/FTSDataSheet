using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using MailSync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Components;
using WebUI.Components.Jqgrid;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = nameof(Roles.FTSAdmin))]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserHelper _userHelper;
        private readonly IRoleService _roleService;
        private readonly ICustomerService _customerService;

        public UserController(IUserService userService, IRoleService roleService,
            ICustomerService customerService)
        {
            _userService = userService;
            _userHelper = new UserHelper();
            _roleService = roleService;
            _customerService = customerService;
        }

        [Route("kullanicilar")]
        public IActionResult UserList()
        {
            return View();
        }

        [Route("musterikullanicilari")]
        public IActionResult CustomerUserList()
        {
            return View();
        }

        public JsonResult UserListDataTable([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _userHelper.CreateSearchExpression(model);

            var userList = _userService.GetAllFTSUsers(
                expression,
                _userHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in userList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.FirstName,
                             a.LastName,
                             a.Email,
                             a.Status == true ? "Aktif" : "Pasif"
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _userService.UserCount(),
                recordsFiltered = _userService.UserCount(expression),
                data = result
            });
        }

        public JsonResult CustomerUserListDataTable([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _userHelper.CreateSearchExpression(model);

            var userList = _userService.GetAllCustomerUsers(
                expression,
                _userHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in userList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.Customer != null ? a.Customer.DisplayName : "",
                             a.FirstName,
                             a.LastName,
                             a.Email,
                             a.Status == true ? "Aktif" : "Pasif"
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _userService.UserCount(),
                recordsFiltered = _userService.UserCount(expression),
                data = result
            });
        }

        [Route("kullanici/{Id}")]
        public ActionResult User(int Id = 0)
        {
            UserViewModel model = new UserViewModel();
            if (Id > 0)
            {
                model.User = _userService.GetById(Id);
                if (model.User.CustomerId != null)
                {
                    return RedirectToAction("CustomerUser", "User", new { Id });
                }
            }
            else
            {
                model.User = new User
                {
                    Id = 0,
                    FirstName = "",
                    LastName = "",
                    Email = "",
                    Status = true,
                };
            }
            model.Roles = _roleService.GetFTSRoles();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdateUser(UserViewModel model)
        {
            var userExists = _userService.UserExists(model.User.Email);
            if (!userExists.Success)
            {
                _userService.Update(model.User);
                return RedirectToAction("User", "User", new { userExists.Data.Id });
            }

            var result = _userService.Register(model.User, model.User.Password);
            if (result.Success)
            {
                return RedirectToAction("User", "User", new { result.Data.Id });
            }

            return RedirectToAction("User", "User", new { result.Data.Id });
        }

        [HttpPost]
        public JsonResult DeleteUser([FromBody]User user)
        {
            try
            {
                _userService.Delete(user);
                return Json("");
            }
            catch (Exception exception)
            {
                return Json("Hata Oluştu.. " + exception.Message);
            }
        }

        public ActionResult UserListByCustomer(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var userlist = _userService.GetUserByCustomerId(Id);
            var result = from a in userlist.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.FirstName,
                             a.LastName,
                             a.Email,
                             a.Password,
                             a.CustomerId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = userlist.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)userlist.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = userlist.Count(),
                rows = result
            });
        }

        public JsonResult AddOrUpdateUserAjax(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    var userExists = _userService.UserExists(user.Email);
                    if (!userExists.Success)
                    {
                        throw new Exception(message: userExists.Message);
                    }
                    user.RoleId = 1;
                    user.Status = true;
                    _userService.Add(user);
                    SendUserMail(user.Id);
                }
                else
                    _userService.Update(user);

                return Json("");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

        }

        [HttpPost]
        public JsonResult DeleteUserAjax(int Id)
        {
            try
            {
                var user = _userService.GetById(Id);
                _userService.Delete(user);
                return Json("");
            }
            catch (Exception exception)
            {
                return Json("Hata Oluştu.. " + exception.Message);
            }
        }

        [Route("musterikullanici/{Id}")]
        public IActionResult CustomerUser(int Id = 0)
        {
            UserViewModel model = new UserViewModel();
            if (Id > 0)
            {
                model.User = _userService.GetById(Id);
                if (model.User.CustomerId == null)
                {
                    return RedirectToAction("User", "User", new { Id });
                }

                if (model.User.CustomerId > 0)
                {
                    model.Customers = _customerService.GetAllCustomers(k => k.Id != model.User.CustomerId);
                    model.Customers.Add(_customerService.GetById((int)model.User.CustomerId));
                }
                else
                {
                    model.Customers = _customerService.GetAllCustomers(skip: 0, take: 10);
                }

            }
            else
            {
                model.User = new User
                {
                    Id = 0,
                    FirstName = "",
                    LastName = "",
                    Email = "",
                    Status = true,
                };
                model.Customers = _customerService.GetAllCustomers();
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult SendUserMail(int Id)
        {
            _userService.SendMailUser(Id);
            
            return Json("Eposta Gönderildi");
        }

    }
}