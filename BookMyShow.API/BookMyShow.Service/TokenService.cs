using BookMyShow.Services.Contracts;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookMyShow.Services
{
    public class TokenService : ITokenService
    {
        IConfiguration _config;

        public TokenService(IConfiguration configuration)
        {
            this._config = configuration;
        }

        public async Task<GoogleJsonWebSignature.Payload> ValidateIdToken(string idToken)
        {
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings());
            return payload;
        }

        public async Task<string> GenerateAccessToken(string idToken)
        {
            GoogleJsonWebSignature.Payload payload = await ValidateIdToken(idToken);
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, payload.Email)
                }),
                SigningCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256),

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}