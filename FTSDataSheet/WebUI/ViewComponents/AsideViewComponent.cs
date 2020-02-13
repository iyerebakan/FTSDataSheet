using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    public class AsideViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public AsideViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public ViewViewComponentResult Invoke()
        {
            AsideViewModel model = new AsideViewModel();
            model.FTSAdmin = false;
            model.Customer = false;
            if (UserIdentityInfo.Roles.Contains(Roles.FTSAdmin))
            {
                model.FTSAdmin = true;
            }
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                model.Customer = true;
                var customer = _userService.GetAllCustomerUsers(k => k.Id == Convert.ToInt32(UserIdentityInfo.Id)).FirstOrDefault();
                if (customer.Customer != null)
                {
                    model.CustomerName = customer.Customer.DisplayName;
                }
            }

            return View(model);
        }
    }
}
