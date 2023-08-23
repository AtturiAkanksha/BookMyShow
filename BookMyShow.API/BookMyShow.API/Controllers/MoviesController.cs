using Microsoft.AspNetCore.Mvc;
using BookMyShow.Services.Contracts;
using BookMyShow.DomainModels;
using BookMyShow.API.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;

namespace BookMyShowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [Route("getMovies")]
        public ApiResponse<IEnumerable<Movie>> GetMovies(string location)
        {
            try
            {
                IEnumerable<Movie> movies = _moviesService.GetMovies(location);
                return ApiResponse<IEnumerable<Movie>>.Success(movies);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Movie>>.Failure(ex.Message);
            }
        }
    }
}
