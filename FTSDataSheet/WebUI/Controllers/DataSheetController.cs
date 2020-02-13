using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;
using WebUI.Components;
using WebUI.Extensions;
using WebUI.Helpers;
using Core.Utilities.LinqKits;
using Entities.Concrete;
using WebUI.Models;
using Entities.Dto;
using Core.Utilities.Export.Excel;
using Core.Utilities.Extensions;
using Entities.Dto.ExcelDto;
using System.IO;
using DataAccess.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    [Authorize]
    public class DataSheetController : Controller
    {
        private readonly IDataSheetService _dataSheetService;
        private readonly DataSheetHelper _dataSheetHelper;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IFileService _fileService;
        public DataSheetController(IDataSheetService dataSheetService,IUserService userService,
                ICustomerService customerService, IFileService fileService)
        {
            _dataSheetService = dataSheetService;
            _dataSheetHelper = new DataSheetHelper();
            _userService = userService;
            _customerService = customerService;
            _fileService = fileService;
        }

        [Route("datasheetlist")]
        public IActionResult DataSheetList()
        {
            ViewBag.addNewbutton = true;
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                ViewBag.addNewbutton = false;
            }
            return View();
        }

        [HttpPost]
        public JsonResult DataSheetListDataTable([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _dataSheetHelper.CreateSearchExpression(model);
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
                if (user.CustomerId != null)
                {
                    if (expression == null)
                        expression = PredicateBuilder.True<DataSheetDto>();
                    expression = expression.And(k => k.CustomerId == user.CustomerId);
                }
            }

            var dataSheetList = _dataSheetService.GetAllDataSheets(
                expression,
                _dataSheetHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in dataSheetList
                         select new[] {
                             a.Id.ToString(),
                             a.DataSheetNumber,
                             a.CustomerName,
                             a.SampleNumber,
                             a.Department,
                             a.YKKProductCode1,
                             a.Status,
                             a.StartDate != null ?a.StartDate.DateStringWithoutTime() : "",
                             a.EndDate != null ?a.EndDate.DateStringWithoutTime() : "",
                             a.FTSUserName,
                             a.MainCustomer,
                             a.TestResult
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _dataSheetService.DataSheetCount(),
                recordsFiltered = _dataSheetService.DataSheetCount(expression),
                data = result
            });
        }

        [Route("datasheet/{Id}")]
        public IActionResult DataSheet(int Id = 0)
        {
            DataSheetViewModel model = new DataSheetViewModel();
            if (Id > 0)
            {
                model.DataSheet = _dataSheetService.GetById(Id);
                if (model.DataSheet == null)
                {
                    return RedirectToAction("DataSheetList", "DataSheet");
                }
                if (UserIdentityInfo.Roles.Contains(Roles.Customer))
                {
                    model.CustomerUser = true;
                    model.CustomerName = _customerService.GetCustomerNameById(model.DataSheet.CustomerId);
                }
                model.Customers = _customerService.GetAllCustomers(k => k.Id != model.DataSheet.CustomerId);
                model.Customers.Add(_customerService.GetById(model.DataSheet.CustomerId));
                model.Files = _fileService.GetFilesByDataSheetCustomer(Id);
            }
            else
            {
                var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
                if (user.CustomerId == null)
                {
                    model.Customers = _customerService.GetAllCustomers();
                    model.DataSheet = new DataSheet
                    {
                        Id = 0,
                        Contact = "",
                        Status = 0
                    };
                }
                else
                {
                    return RedirectToAction("DataSheetList", "DataSheet");
                    //model.CustomerUser = true;
                    //var customer = _customerService.GetById((int)user.CustomerId);
                    //model.DataSheet = new DataSheet
                    //{
                    //    Id = 0,
                    //    CustomerId = customer.Id,
                    //    Contact = user.FirstName + " " + user.LastName,
                    //    EmailAddress = customer.EmailAddress,
                    //    TelephoneNumber = customer.TelephoneNumber,
                    //    FaxNumber = customer.FaxNumber,
                    //    Status = 0
                    //};
                    //model.CustomerName = customer.DisplayName;
                } 
            }
            return View(model);
        }

        //public IActionResult DataSheet(int Id = 0)
        //{
        //    DataSheetViewModel model = new DataSheetViewModel();
        //    if (Id > 0)
        //    {
        //        model.DataSheet = _dataSheetService.GetById(Id);
        //        if (model.DataSheet == null)
        //        {
        //            return RedirectToAction("DataSheetList", "DataSheet");
        //        }
        //        if (UserIdentityInfo.Roles.Contains(Roles.Customer))
        //        {
        //            model.CustomerUser = true;
        //            var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
        //            if (user.CustomerId != model.DataSheet.CustomerId)
        //            {
        //                return RedirectToAction("DataSheetList", "DataSheet");
        //            }
        //        }
        //        model.CustomerName = _customerService.GetCustomerNameById(model.DataSheet.CustomerId);
        //        model.Files = _fileService.GetFilesByDataSheetCustomer(Id);
        //    }
        //    else
        //    {
        //        var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
        //        if(user.CustomerId == null)
        //            return RedirectToAction("DataSheetList", "DataSheet");

        //        var customer = _customerService.GetById((int)user.CustomerId);
        //        model.DataSheet = new DataSheet
        //        {
        //            Id = 0,
        //            CustomerId = customer.Id,
        //            Contact = user.FirstName + " " + user.LastName,
        //            EmailAddress = customer.EmailAddress,
        //            TelephoneNumber = customer.TelephoneNumber,
        //            FaxNumber = customer.FaxNumber,
        //            Status = 0
        //        };
        //        model.CustomerName = customer.DisplayName;
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult AddOrUpdateDataSheet(DataSheetViewModel model)
        {
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
                if (user.CustomerId != model.DataSheet.CustomerId)
                {
                    model.DataSheet.CustomerId = (int)user.CustomerId;
                }
            }

            if (model.DataSheet.Id == 0)
            {
                model.DataSheet.CreateDate = DateTime.Now;
                model.DataSheet.CreateUser = Convert.ToInt32(UserIdentityInfo.Id);
                _dataSheetService.Add(model.DataSheet);
            }
            else
            {
                model.DataSheet.UpdateDate = DateTime.Now;
                model.DataSheet.UpdateUser = Convert.ToInt32(UserIdentityInfo.Id);
                _dataSheetService.Update(model.DataSheet);
            }
            return RedirectToAction("DataSheet", "DataSheet", new { model.DataSheet.Id });
        }

        [HttpPost]
        public JsonResult StartEndDataSheetProcess(int Id, int status)
        {
            var error = "";
            try
            {
                var datasheet = _dataSheetService.GetById(Id);
                datasheet.Status = status;
                if (status == 1)
                {
                    //datasheet.StartDate = DateTime.Now;
                }
                else if (status == 2)
                {
                    //datasheet.EndDate = DateTime.Now;
                }
                datasheet.UpdateDate = DateTime.Now;
                datasheet.UpdateUser = Convert.ToInt32(UserIdentityInfo.Id);
                _dataSheetService.Update(datasheet);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(error);
        }

        [HttpPost]
        public JsonResult DeleteDataSheet([FromBody]DataSheet model)
        {
            try
            {
                _dataSheetService.Delete(model);
                return Json("");
            }
            catch (Exception exception)
            {
                return Json("Hata Oluştu.. " + exception.Message);
            }
        }

        [HttpPost]
        public JsonResult FTSDataSheetListDataTable([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _dataSheetHelper.CreateSearchExpression(model);
            if (expression == null)
                expression = PredicateBuilder.True<DataSheetDto>();
            expression = expression.And(k => k.StatusId == 0);

            var dataSheetList = _dataSheetService.GetAllDataSheets(
                expression,
                _dataSheetHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in dataSheetList
                         select new[] {
                             a.Id.ToString(),
                             a.CustomerName,
                             a.DataSheetNumber,
                             a.CreateUserName,
                             a.CreateDate.ToString(),
                             a.Department,
                             a.MainCustomer,
                             a.SampleNumber,
                             a.Status,
                             a.TestResult
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _dataSheetService.DataSheetCount(),
                recordsFiltered = _dataSheetService.DataSheetCount(expression),
                data = result
            });
        }

        [HttpPost]
        public JsonResult FTSAdminDataSheetListDataTable([FromBody] DataTableAjaxPostModel model,int status)
        {
            var expression = _dataSheetHelper.CreateSearchExpression(model);
            if (expression == null)
                expression = PredicateBuilder.True<DataSheetDto>();
            expression = expression.And(k => k.StatusId == status);

            var dataSheetList = _dataSheetService.GetAllDataSheets(
                expression,
                _dataSheetHelper.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in dataSheetList
                         select new[] {
                             a.Id.ToString(),
                             a.FTSUserName,
                             a.CustomerName,
                             a.DataSheetNumber,
                             a.CreateUserName,
                             a.CreateDate.ToString(),
                             a.Department,
                             a.MainCustomer,
                             a.SampleNumber,
                             a.TestResult
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _dataSheetService.DataSheetCount(),
                recordsFiltered = _dataSheetService.DataSheetCount(expression),
                data = result
            });
        }

        public IActionResult ExportDataSheet(string filter)
        {
            var expression = _dataSheetHelper.SearchForExcel(filter);
            if (expression == null)
                expression = PredicateBuilder.True<DataSheet>();
            expression = expression.And(k => k.FTSUser == null);

            List<DataSheetWaitingForAdminDto> dataSheetDtos = _dataSheetService.GetDataSheetWaitingForAdminDtos(expression);
            string[] columns = { "Müşteri Adı","Kayıt No", "Kayıt Yapan", "Kayıt Tarihi", "Departman", "Ana Müşteri", "Ana Müşteri Model No",
                "Model No", "Durum" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(dataSheetDtos, "FTSDataSheet", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "FTSDataSheet.xlsx");
        }

        [HttpGet]
        public JsonResult PrintFormPDF(int Id)
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + "\\wwwroot\\DataSheetForm\\index.html";
                string value = System.IO.File.ReadAllText(path);

                var model = _dataSheetService.GetById(Id);
                string customerName = _customerService.GetCustomerNameById(model.CustomerId);
                if (model != null)
                {
                    value = new PrintForm().DataSheetPrint(value, model, customerName);
                }
                else
                {
                    throw new Exception();
                }

                return Json(value);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Export([FromBody] DataTableAjaxPostModel model)
        {
            var expression = _dataSheetHelper.CreateSearchExpression(model);
            if (UserIdentityInfo.Roles.Contains(Roles.Customer))
            {
                var user = _userService.GetById(Convert.ToInt32(UserIdentityInfo.Id));
                if (user.CustomerId != null)
                {
                    if (expression == null)
                        expression = PredicateBuilder.True<DataSheetDto>();
                    expression = expression.And(k => k.CustomerId == user.CustomerId);
                }
            }
            List<DataSheetDto> dataSheetDtos = _dataSheetService.GetAllDataSheets(expression,take:10000);
            string[] columns = { "Müşteri Adı", "Kayıt Yapan", "Kayıt Tarihi", "Departman", "Ana Müşteri", "Ana Müşteri Model No",
                "Model No", "Durum" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(dataSheetDtos, "FTSDataSheet", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "FTSDataSheet.xlsx");
        }
    }
}