using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_catalog_react.Helpers
{
    public class JwtService
    {
        private string secureKey = "this is secure key";

        public string Generate(int id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header =new JwtHeader(credentials);

            var payLoad = new JwtPayload(id.ToString(), null, null, null, DateTime.Now.AddDays(1));//1 day
            var securityToken = new JwtSecurityToken(header, payLoad);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler= new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer =false,
                ValidateAudience=false

            }, out SecurityToken validatedToken); ;
            return (JwtSecurityToken)validatedToken;

        }
    }
}
