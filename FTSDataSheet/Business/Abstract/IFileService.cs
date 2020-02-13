using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFileService
    {
        List<File> GetFilesByDataSheetCustomer(int datasheetId);
        List<File> GetFilesByDataSheetFTS(int datasheetId);
        File GetById(int id);
        void Add(File file);
        void Delete(File file);
    }
}
