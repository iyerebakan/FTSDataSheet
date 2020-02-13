using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IFileDal _fileDal;
        public FileManager(IFileDal fileDal)
        {
            _fileDal = fileDal;
        }
        public void Add(File file)
        {
            _fileDal.Add(file);
        }

        public void Delete(File file)
        {
            _fileDal.Delete(file);
        }

        public File GetById(int id)
        {
            return _fileDal.Get(k => k.Id == id);
        }

        public List<File> GetFilesByDataSheetCustomer(int datasheetId)
        {
            return _fileDal.GetAll(k => k.DataSheetId == datasheetId && k.Uploader == "MUSTERI");
        }

        public List<File> GetFilesByDataSheetFTS(int datasheetId)
        {
            return _fileDal.GetAll(k => k.DataSheetId == datasheetId && k.Uploader == "FTS");
        }
    }
}
