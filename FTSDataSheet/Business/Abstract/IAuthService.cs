using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> CustomerUserLogin(UserForLoginDto userForLoginDto);
        IDataResult<User> FTSUserLogin(UserForLoginDto userForLoginDto);
    }
}
