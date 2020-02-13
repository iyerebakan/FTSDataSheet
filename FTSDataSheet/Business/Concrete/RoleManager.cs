using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public List<Role> GetFTSRoles()
        {
            return _roleDal.GetAll(k => k.Name != Roles.Customer).ToList();
        }
    }
}
