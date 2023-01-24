using Business.Abstract;
using Business.PasswordHash;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity;
using Entity.Dto;
using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            var claim = _userService.GetUserClaims(user);
            var accessToken =  _tokenHelper.CreateToken(user,claim);
            return new SuccessDataResult<User>(accessToken, "Token Created");
        }

        public IDataResult<User> Login(UserForLoginDto userforlogindto)
        {
            var userToCheck = _userService.GetEmail(userforlogindto.Email);
            if (userToCheck ==  null)
            {
                return new ErrorDataResult<User>("User not found");
            }

            if (!HashHelper.VerifyPassword(userforlogindto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Password fault");
            }

            return new SuccessDataResult<User>(userToCheck,"Login Succesfull");
        }

        public IDataResult<User> Register(UserForRegisterDto userforregisterdto, string password)
        {
            byte[] passwordhash;
            byte[] passwordsalt;

            HashHelper.CreatePassword(password, out passwordhash, out passwordsalt);
            var user = new User
            {
                Email = userforregisterdto.Email,
                FirstName = userforregisterdto.FirstName,
                LastName = userforregisterdto.LastName,
                PasswordHash = passwordhash,
                PasswordSalt = passwordsalt,
                Status = true
            };
            _userService.add(user);
            return new SuccessDataResult<User>(user, "Registered");

        }

        public IResult UserExist(string email)
        {
            if (_userService.GetEmail(email) == null)
            {
                return new ErrorResult("sdsdsdsd");
            }
            return new SuccessResult();
        }
    }
}
