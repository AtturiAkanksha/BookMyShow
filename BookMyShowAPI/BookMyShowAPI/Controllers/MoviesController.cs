using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using DomainModels;

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

        [HttpPost]
        [Route("getMovies")]
        public IActionResult GetMovies([FromBody] string location)
        {
            try
            {
                IEnumerable<Movie> movies = _moviesService.GetMovies(location);
                return Ok(movies);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
