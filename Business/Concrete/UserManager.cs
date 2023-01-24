using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }
        public void add(User user)
        {
           _userdal.add(user);
        }

        public User GetEmail(string email)
        {
            return null;
        }

        public List<OperationClaim> GetUserClaims(User user)
        {
          return   _userdal.GetClaim(user);
        }
    }
}
