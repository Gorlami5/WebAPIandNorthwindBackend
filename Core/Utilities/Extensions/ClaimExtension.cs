using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions
{
    public static class ClaimExtension
    {
        public static void AddEmail(this ICollection<Claim> claims,string email) //bir metodu extend etmek istediğimizde kullanırız
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }


        public static void AddName(this ICollection<Claim> claims, string name) 
        {
            claims.Add(new Claim(ClaimTypes.Name,name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameid) 
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameid));
        }
        public static void AddRole(this ICollection<Claim> claims, string[] roles) 
        {
            roles.ToList().ForEach(roles => claims.Add(new Claim(ClaimTypes.Role,roles)));
        }
    }
}
