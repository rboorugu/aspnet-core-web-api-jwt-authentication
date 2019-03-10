using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Helpers;
using WebApi.Data;
using System.Collections.Generic;

namespace WebApi.Services
{
    public interface ILoginService
    {
        string Authenticate(string username, string password);
    }

    public class LoginService : ILoginService
    {       

        private readonly JwtSettings _jwtSettings;

        public LoginService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string Authenticate(string username, string password)
        {
            var user = Users.GetUsers().SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

            // authentication successful so generate jwt token
            var token = new JwtSecurityToken(
                  issuer: _jwtSettings.Site,
                  audience: _jwtSettings.Site,
                  expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtSettings.ExpiryInMinutes)),
                  signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey)), SecurityAlgorithms.HmacSha256),
                  claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}