using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.ExcelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IDataSheetDal : IEntityRepository<DataSheet>
    {
        List<DataSheetDto> GetDataSheetDtos(Expression<Func<DataSheetDto, bool>> filter = null, Func<IQueryable<DataSheetDto>, 
            IOrderedQueryable<DataSheetDto>> orderBy = null,
            int skip = 0, int take = 0);
        int GetDataSheetDtosCount(Expression<Func<DataSheetDto, bool>> filter = null);

        List<DataSheetWaitingForAdminDto> GetDataSheetWaitingForAdminDtos(Expression<Func<DataSheet, bool>> filter = null);

        List<DataSheetMonthlyDto> GetDataSheetMonthlyDtos();
        List<DataSheetYearlyDto> GetDataSheetYearlyDtos();

        List<DataSheetCities> GetDataSheetCities();
    }
}
