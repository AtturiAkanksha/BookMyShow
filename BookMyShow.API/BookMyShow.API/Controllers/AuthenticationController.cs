using BookMyShow.DomainModels;
using BookMyShow.API.ResponseDTOs;
using BookMyShow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("getToken")]
        public ApiResponse<Task<string>> GetJwt(AuthRequest authRequest)
        {
            try
            {
                Task<string> accessToken = _tokenService.GetJwt(authRequest);
                return ApiResponse<Task<string>>.Success(accessToken);
            }
            catch (Exception ex)
            {
                return ApiResponse<Task<string>>.Failure(ex.Message);
            }
        }
    }
}
