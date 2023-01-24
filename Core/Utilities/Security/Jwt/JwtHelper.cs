using Core.Utilities.Extensions;
using Core.Utilities.Security.Encryption;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration configuration1 { get; set; }
        public TokenOptions _tokenOptions;
        public DateTime _accesstokenExpries;

        public JwtHelper(IConfiguration configuration)
        {
            configuration1 = configuration;
            _tokenOptions = configuration1.GetSection("TokenOptions").Get<TokenOptions>();  //appsettings.json mapping
            _accesstokenExpries = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) 
        {
            var securitKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); 
            var signingcredential = SigningCredentialHelper.CreateSigningCredential(securitKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingcredential, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); //?
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken()
            {
                Token = token,
                Expiration = _accesstokenExpries
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenoptions,User user, SigningCredentials signingcredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenoptions.Issuer,
                audience: tokenoptions.Audience,
                expires: _accesstokenExpries,
                notBefore:DateTime.Now,
                claims:SetClaim(user,operationClaims),
                signingCredentials: signingcredentials
                );
            return jwt;
        }

        public IEnumerable<Claim> SetClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>(); //List kullanım örneği
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRole(operationClaims.Select(c=> c.Name).ToArray());
            return claims;
        }
    }
}
