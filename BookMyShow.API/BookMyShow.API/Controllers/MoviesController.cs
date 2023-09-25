using Microsoft.AspNetCore.Mvc;
using BookMyShow.Services.Contracts;
using BookMyShow.DomainModels;
using BookMyShow.API.ResponseDTOs;
using Microsoft.Extensions.Caching.Distributed;
using BookMyShow.Services;

namespace BookMyShowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IDistributedCache _cache;
        public MoviesController(IMoviesService moviesService, IDistributedCache cache)
        {
            _moviesService = moviesService;
            _cache = cache;
        }

        [HttpGet]
        [Route("getMovies")]
        public ApiResponse<IEnumerable<Movie>> GetMovies(string location)
        {
            try
            {
                string key = $"moviesIn{location}";
                IEnumerable<Movie> cachedMovies = _cache.GetData<IEnumerable<Movie>>(key);
                if (cachedMovies == null)
                {
                    IEnumerable<Movie> movies = _moviesService.GetMovies(location);
                    _cache.SetData(key, movies);
                    return ApiResponse<IEnumerable<Movie>>.Success(movies);
                }
                return ApiResponse<IEnumerable<Movie>>.Success(cachedMovies);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Movie>>.Failure(ex.Message);
            }
        }
    }
}
