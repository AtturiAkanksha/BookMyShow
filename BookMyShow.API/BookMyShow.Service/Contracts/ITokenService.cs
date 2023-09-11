using BookMyShow.DomainModels;
using Google.Apis.Auth;
using System.Security.Claims;

namespace BookMyShow.Services.Contracts
{
    public interface ITokenService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateGoogleIdToken(string idToken);
        ClaimsPrincipal ValidateMicrosoftIdToken(string idToken);
        Task<string> GetUserRole(string email);
        string GenerateJwt(string email, string role);
        Task<string> GetJwt(AuthRequest authRequest);
    }
}
