using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.ExcelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IDataSheetService
    {
        List<DataSheetDto> GetAllDataSheets(Expression<Func<DataSheetDto, bool>> filter = null,
        Func<IQueryable<DataSheetDto>, IOrderedQueryable<DataSheetDto>> orderby = null, int skip = 0, int take = 10);
        void Add(DataSheet dataSheet);
        void Update(DataSheet dataSheet);
        void Delete(DataSheet dataSheet);
        int DataSheetCount(Expression<Func<DataSheetDto, bool>> filter = null);
        DataSheet GetById(int Id);
        List<DataSheetWaitingForAdminDto> GetDataSheetWaitingForAdminDtos(Expression<Func<DataSheet, bool>> filter = null);
        string GetLastDataSheetNumberForCustomer(int customerid);

        List<DataSheetMonthlyDto> DataSheetCountMonty();
        List<DataSheetYearlyDto> DataSheetCountYearly();
        int DataSheetElapsedTime();
        List<DataSheetCities> GetDataSheetCities();
    }
}
