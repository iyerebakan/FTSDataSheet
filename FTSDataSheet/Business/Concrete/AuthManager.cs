using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<User> CustomerUserLogin(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMailForCustomerUser(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (userToCheck.Password != userForLoginDto.Password)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            //if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            //{
            //    return new ErrorDataResult<User>(Messages.PasswordError);
            //}

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> FTSUserLogin(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMailForFTSUser(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (userToCheck.Password != userForLoginDto.Password)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            //if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            //{
            //    return new ErrorDataResult<User>(Messages.PasswordError);
            //}

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

    }
}
