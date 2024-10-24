using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeknorixJobs.API.Global;
using TeknorixJobs.Application.DTOs.Authorize;

namespace TeknorixJobs.API.Helper;

public class AuthorizedService
{
    private readonly AuthorizedApp _authApp = null;
    public AuthorizedService()
    {
        _authApp = new AuthorizedApp();
    }
    public string? GenerateToken(AuthorizedDetailsDto details)
    {
        if (details.ClientAppId == _authApp.ClientAppId && details.ClientSecret == _authApp.ClientSecret)
        {
            // Generate a JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(AuthorizedKeys.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("ClientAppId", details.ClientAppId, ClaimValueTypes.String)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = AuthorizedKeys.Issuer,
                Audience = AuthorizedKeys.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        else
            return null;
    }
}
