using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PasswordHash
{
    public static class HashHelper
    {
        public static void CreatePassword (string password, out byte[] passwordhash, out byte[] passwordsalt )
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPassword(string password,byte[] passwordhash,byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
             var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordhash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
