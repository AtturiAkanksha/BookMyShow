using Google.Apis.Auth;

namespace BookMyShow.Services.Contracts
{
    public interface ITokenService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken);
        Task<string> GenerateToken(string idToken);
    }
}
