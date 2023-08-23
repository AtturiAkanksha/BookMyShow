using Google.Apis.Auth;

namespace BookMyShow.Services.Contracts
{
    public interface ITokenService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateIdToken(string idToken);
        Task<string> GenerateAccessToken(string idToken);

    }
}
