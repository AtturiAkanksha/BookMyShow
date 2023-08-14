using AutoMapper;
using BookMyShow.Data.IRepositories;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITheatreService _theatreService;

        public MoviesService(ITheatreRepository theatreRepository, IMoviesRepository moviesRepository, ITheatreService theatreService)
        {
            _theatreService = theatreService;
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<DomainModels.Movie> GetMovies(string location)
        {
            try
            {
                IEnumerable<DomainModels.Theatre> theatres = _theatreService.GetTheatresByLocation(location);
                if (theatres.Any())
                {
                    List<int> movieIds = theatres
                        .SelectMany(t => t.MovieIds)
                        .ToList();
                    IEnumerable<DomainModels.Movie> movies = _moviesRepository.GetMovies(movieIds);
                    return movies;
                }
                throw new Exception("No theatres found in the given location");
            }
            catch
            {
                throw;
            }
        }
    }
}
