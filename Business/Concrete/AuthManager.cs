using Business.Abstract;
using Business.Constans;
using Business.Validation.FluentValidation;
using Core.Asbect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var result = _userService.GetByMail(userForLoginDto.Email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, result.PasswordHash, result.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(result, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {   
            var userExist = UserExists(userForRegisterDto.Email);
            if (!userExist.Success)
            {
                return new ErrorDataResult<User>(userExist.Message);
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Gsm=userForRegisterDto.Gsm,
                    CreatedBy=userForRegisterDto.CreatedBy,
                    CreatedDate=DateTime.Now,
                    ModifiedBy=userForRegisterDto.ModifiedBy,
                    ModifiedDate=DateTime.Now,
                    Status=userForRegisterDto.Status

                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }
        }


        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        [ValidationAspect(typeof(ChangePasswordValidator))]
       public IResult ChangePassword(ChangePassword updateUser)
        {
            UserForLoginDto checkedUser = new UserForLoginDto
            {
                Email = updateUser.Email,
                Password = updateUser.OldPassword
                
            };
            var loginResult = Login(checkedUser);
            if (loginResult.Success)
            {
                var user = loginResult.Data;
                byte[] passwordHash,passwordSalt;
                HashingHelper.CreatePasswordHash(updateUser.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _userService.PasswordUpdate(user);
                return new SuccessResult(Messages.PasswordChanged);
            }
            return new ErrorResult(loginResult.Message);
        }
    }
}
