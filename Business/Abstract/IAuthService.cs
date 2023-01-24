using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public IDataResult<User> Register(UserForRegisterDto userforregisterdto,string password);

        public IDataResult<User> Login(UserForLoginDto userforlogindto);

        public IResult UserExist(string email);

        public IDataResult<AccessToken> CreateToken(User user);
    }
}
