using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto_SAPi.Security
{
    public class TokenGenerator
    {
        public static string GetToken(User user, byte[] key)
        {
            var claim = GetClaims(user);
            var token = new JwtSecurityToken(
                    claims: claim,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static Claim[] GetClaims(User user)
        {
            return [
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.IdRoleNavigation.Name),
                ];
        }
    }
}
