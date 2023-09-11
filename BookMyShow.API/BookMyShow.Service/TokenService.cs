using BookMyShow.DomainModels;
using BookMyShow.Services.Contracts;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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

        public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleIdToken(string idToken)
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

        public ClaimsPrincipal ValidateMicrosoftIdToken(string idToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"https://login.microsoftonline.com/{_configuration["AzureAd:TenantId"]}/v2.0/.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever());
                var openIdConfig = configurationManager.GetConfigurationAsync().Result;
                var validationParameters = new TokenValidationParameters
                {
                    ValidAudience = _configuration["AzureAd:ClientId"],
                    ValidIssuer = $"https://login.microsoftonline.com/{_configuration["AzureAd:TenantId"]}/v2.0",
                    IssuerSigningKeys = openIdConfig.SigningKeys,
                };
                SecurityToken validatedToken;
                return tokenHandler.ValidateToken(idToken, validationParameters, out validatedToken);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetUserRole(string email)
        {
            string userRole;
            User user = await _userService.GetUser(email);
            if (user == null)
            {
                userRole = "public user";
            }
            else
            {
                userRole = user.Role;
            }
            return userRole;
        }

        public string GenerateJwt(string email, string role)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddDays(7),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                SigningCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GetJwt(AuthRequest authRequest)
        {
            string userRole;
            try
            {
                if (authRequest.Provider == "GOOGLE")
                {
                    GoogleJsonWebSignature.Payload payload = await ValidateGoogleIdToken(authRequest.IdToken);
                    if(payload != null) { }
                    userRole = await GetUserRole(payload.Email);
                    return GenerateJwt(payload.Email, userRole);
                }
                else
                {
                    ClaimsPrincipal claimsPrincipal = ValidateMicrosoftIdToken(authRequest.IdToken);
                    userRole = await GetUserRole(claimsPrincipal.FindFirst(ClaimTypes.Email).Value);
                    return GenerateJwt(claimsPrincipal.FindFirst(ClaimTypes.Email).Value, userRole);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}