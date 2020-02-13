using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUI.Extensions;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IDataSheetService _dataSheetService;
        private readonly ICustomerService _customerService;
        public IConfiguration Configuration { get; }
        private FileHelper fileHelper;
        public FileController(IFileService fileService, IConfiguration configuration,
            IDataSheetService dataSheetService,ICustomerService customerService)
        {
            _fileService = fileService;
            Configuration = configuration;
            fileHelper = Configuration.GetSection("FileOptions").Get<FileHelper>();
            _dataSheetService = dataSheetService;
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<JsonResult> AddFile(IEnumerable<IFormFile> file, int Id)
        {
            string error = "";
            try
            {
                foreach (var item in file)
                {
                    string filename = item.FileName;
                    int index = filename.LastIndexOf("\\");
                    filename = filename.Substring(index + 1, filename.Length - index - 1);

                    var folder = CreateOrUpdateFolder(Id,fileHelper.FilePath);
                    var filePath = Path.Combine(folder, "FTS", filename);
                    if (UserIdentityInfo.Roles.Contains(Roles.Customer))
                    {
                        filePath = Path.Combine(folder, "MUSTERI", filename);
                    }                      
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    Entities.Concrete.File fileBox = new Entities.Concrete.File();
                    fileBox.DataSheetId = Id;
                    fileBox.FileName = filename;
                    fileBox.FilePath = filePath;
                    fileBox.ContentType = item.ContentType;
                    fileBox.Uploader = "MUSTERI";
                    fileBox.CreateDate = DateTime.Now;
                    fileBox.CreateUser = Convert.ToInt32(UserIdentityInfo.Id);
                    _fileService.Add(fileBox);

                    if (UserIdentityInfo.Roles.Contains(Roles.FTSUser))
                    {
                        var datasheet = _dataSheetService.GetById(Id);
                        datasheet.FTSUserId = Convert.ToInt32(UserIdentityInfo.Id);
                        _dataSheetService.Update(datasheet);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(error);
        }

        private string CreateOrUpdateFolder(int Id,string path)
        {
            var dataSheet = _dataSheetService.GetById(Id);
            if (dataSheet.CustomerId != 0)
            {
                var customer = _customerService.GetById(dataSheet.CustomerId);
                var filepath = path + "\\" + customer.CustomerCode;

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var formcode = "000000" + Id.ToString();
                formcode = formcode.Substring(formcode.Length - 6);

                if (!Directory.Exists(filepath + "\\" + formcode))
                {
                    Directory.CreateDirectory(filepath + "\\" + formcode);
                }

                if (!Directory.Exists(filepath + "\\" + formcode + "\\MUSTERI"))
                {
                    Directory.CreateDirectory(filepath + "\\" + formcode + "\\MUSTERI");
                }

                if (!Directory.Exists(filepath + "\\" + formcode + "\\FTS"))
                {
                    Directory.CreateDirectory(filepath + "\\" + formcode + "\\FTS");
                }
                return filepath + "\\" + formcode;
            }
            return "";
        }

        public IActionResult DownloadFile(int Id)
        {
            var document = _fileService.GetById(Id);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = document.FileName,
                Inline = false,
            };
            byte[] fileBytes = System.IO.File.ReadAllBytes(document.FilePath);

            Response.Headers.Add("Content-Disposition", cd.ToString());
            return File(fileBytes, document.ContentType);
        }

        public async Task<JsonResult> DeleteFile(int Id)
        {
            string error = "";
            try
            {
                var file = _fileService.GetById(Id);
                if (System.IO.File.Exists(file.FilePath))
                {
                    System.IO.File.Delete(file.FilePath);
                }
                _fileService.Delete(file);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(error);
        }
    }
}