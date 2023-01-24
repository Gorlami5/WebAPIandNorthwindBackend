using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securitykey)
        {
            return new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
