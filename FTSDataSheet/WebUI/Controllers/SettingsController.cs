using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = nameof(Roles.FTSAdmin))]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [Route("ayarlar")]
        public IActionResult Settings()
        {
            SettingsViewModel model = new SettingsViewModel
            {
                MailSetting = _settingsService.GetMailSetting()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMailSetting(SettingsViewModel model)
        {
            if(model.MailSetting.Id > 0)
            {
                _settingsService.UpdateMailSetting(model.MailSetting);
            }
            else
            {
                _settingsService.AddMailSetting(model.MailSetting);
            }
            return RedirectToAction("Settings");
        }
    }
}