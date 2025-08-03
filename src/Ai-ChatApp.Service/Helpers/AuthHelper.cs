using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ai_ChatApp.Service.Helpers;

public static class AuthHelper
{
    public static string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(EnvironmentHelper.JWTKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim("Email", user.Email),
                 new Claim(ClaimTypes.Role, Role.User)
            }),
            Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(EnvironmentHelper.TokenLifeTimeInHours)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}