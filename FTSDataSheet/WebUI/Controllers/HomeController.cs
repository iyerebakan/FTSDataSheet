using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Components.Charts;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDataSheetService _dataSheetService;
        
        public HomeController(IUserService userService,IDataSheetService dataSheetService)
        {
            _userService = userService;
            _dataSheetService = dataSheetService;
        }

        public IActionResult Index()
        {
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                return RedirectToAction("CustomerIndex", "Home");
            }
            if (UserIdentityInfo.Roles.Contains(Roles.FTSUser))
            {
                return RedirectToAction("FTSIndex", "Home");
            }
            return RedirectToAction("FTSAdminIndex", "Home");
        }

        [Route("musterianasayfa")]
        public IActionResult CustomerIndex()
        {
            var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
            if (user.CustomerId != null)
            {
                CustomerIndexViewModel model = new CustomerIndexViewModel();
                model.DataSheetDtos = _dataSheetService.GetAllDataSheets(k => k.CustomerId == user.CustomerId,take:1000);
                return View(model);
            }
            return View();
        }

        [Route("ftsanasayfa")]
        public IActionResult FTSIndex()
        {
            CustomerIndexViewModel model = new CustomerIndexViewModel();
            model.DataSheetDtos = _dataSheetService.GetAllDataSheets
                (k => k.FTSUser == Convert.ToInt32(UserIdentityInfo.Id) && k.StatusId == 1,take:1000);
            return View(model); 
        }

        [Route("ftsadminanasayfa")]
        public IActionResult FTSAdminIndex()
        {        
            return View();
        }

        [HttpPost]
        public JsonResult PieChartIndex()
        {
            var nostart = _dataSheetService.GetDataSheetCities();

            var istanbul = nostart.Where(k => k.CityId == 34).Count();
            var denizli = nostart.Where(k => k.CityId == 20).Count();
            var izmir = nostart.Where(k => k.CityId == 35).Count();
            var diger = nostart.Where(k => k.CityId != 34 && k.CityId != 20 && k.CityId != 35).Count();

            List<PieChart> pieCharts = new List<PieChart>();
            if(istanbul > 0)
            {
                pieCharts.Add(new PieChart
                {
                    Color = "rgba(0, 86, 133, 1)",
                    Highlight = "rgba(169, 3, 41, 0.7)",
                    Result = istanbul,
                    Label = "İstanbul"
                });
            }
            if (denizli > 0)
            {
                pieCharts.Add(new PieChart
                {
                    Color = "rgba(194, 68, 0, 1)",
                    Highlight = "rgba(151,187,205,0.8)",
                    Result = denizli,
                    Label = "Denizli"
                });
            }
            if (izmir > 0)
            {
                pieCharts.Add(new PieChart
                {
                    Color = "rgba(104, 95, 90, 1)",
                    Highlight = "rgba(151,187,205,0.8)",
                    Result = izmir,
                    Label = "İzmir"
                });
            }
            if (diger > 0)
            {
                pieCharts.Add(new PieChart
                {
                    Color = "rgba(151,187,205,1)",
                    Highlight = "rgba(151,187,205,0.8)",
                    Result = diger,
                    Label = "Diğer"
                });
            }

            return Json(pieCharts);
        }

        [HttpPost]
        public JsonResult BarChartIndex()
        {
            var ongoing = _dataSheetService.DataSheetCountMonty();
            List<BarData> barDatas = new List<BarData>();

            foreach (var item in ongoing.OrderBy(k => k.Month).OrderBy(k => k.Year))
            {
                barDatas.Add(new BarData
                {
                    Name = item.Description,
                    Data = item.Count
                });
            }

            BarChart barChart = new BarChart
            {
                FillColor = "rgba(10,122,128,1)",
                StrokeColor = "rgba(220,220,220,0.8)",
                HighlightFill = "rgba(220,220,220,0.75)",
                HighlightStroke = "rgba(220,220,220,1)",
                Datas = barDatas
            };

            return Json(barChart);
        }

        [HttpPost]
        public JsonResult BarChartIndexYearly()
        {
            var ongoing = _dataSheetService.DataSheetCountYearly();
            List<BarData> barDatas = new List<BarData>();

            foreach (var item in ongoing.OrderBy(k => k.Month).OrderBy(k => k.Year))
            {
                barDatas.Add(new BarData
                {
                    Name = item.Description,
                    Data = item.Average
                });
            }

            BarChart barChart = new BarChart
            {
                FillColor = "rgba(173,166,20,1)",
                StrokeColor = "rgba(220,220,220,0.8)",
                HighlightFill = "rgba(220,220,220,0.75)",
                HighlightStroke = "rgba(220,220,220,1)",
                Datas = barDatas
            };

            return Json(barChart);
        }

        [HttpPost]
        public JsonResult PieChartIndexTop5()
        {
            var nostart = _dataSheetService.GetDataSheetCities();

            var list = nostart.GroupBy(k => k.Customer).Take(5).OrderByDescending(k => k.Count());

            string[] color = new string[] { "rgba(0, 86, 133, 1)", "rgba(194, 68, 0, 1)",
                    "rgba(104, 95, 90, 1)","rgba(151,187,205,1)","rgba(165, 29, 52, 1)" };


            List <PieChart> pieCharts = new List<PieChart>();
            int k = 0;
            foreach (var item in list)
            {
                pieCharts.Add(new PieChart
                {
                    Color = color[k],
                    Highlight = "rgba(169, 3, 41, 0.7)",
                    Result = item.Count(),
                    Label = item.Key
                });
                k++;
            }


            return Json(pieCharts);
        }

    }
}
