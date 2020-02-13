using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCityDal : EfEntityRepositoryBase<City, FTSDataSheetContext>, ICityDal
    {
    }
}
