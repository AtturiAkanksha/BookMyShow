using BookMyShow.DomainModels;
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
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _goolgeSettings;
        private readonly IUserService _userService;

        public TokenService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
                };
                GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
                return payload;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GenerateToken(string idToken)
        {
            try
            {
                string userRole;
                GoogleJsonWebSignature.Payload payload = await VerifyGoogleToken(idToken);
                User user = await _userService.GetUser(payload.Email);
                if (user == null)
                {
                    userRole = "public user";
                }
                else
                {
                    userRole = user.Role;
                }
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    Expires = DateTime.UtcNow.AddDays(7),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, payload.Subject),
                    new Claim(ClaimTypes.Name, payload.Name),
                    new Claim(ClaimTypes.Email, payload.Email),
                    new Claim(ClaimTypes.Role, userRole)
                    }),
                    SigningCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch
            {
                throw;
            }
        }
    }
}