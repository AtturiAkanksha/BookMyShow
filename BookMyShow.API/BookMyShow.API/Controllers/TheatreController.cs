using Microsoft.AspNetCore.Mvc;
using BookMyShow.Services.Contracts;
using BookMyShow.DomainModels;
using BookMyShow.API.ResponseDTOs;

namespace BookMyShowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService _theatreService;

        public TheatreController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpPost]
        [Route("reservedSeatsData")]
        public ApiResponse<IEnumerable<ReservedSeat>> GetReservedSeats([FromBody] ReservedSeat reserveSeatsRequest)
        {
            try
            {
                IEnumerable<ReservedSeat> seats = _theatreService.GetReservedSeats(reserveSeatsRequest);
                return ApiResponse<IEnumerable<ReservedSeat>>.Success(seats);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ReservedSeat>>.Failure(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ApiResponse<Theatre> Get(int id)
        {
            try
            {
                Theatre theatre = _theatreService.GetTheatreById(id);
                return ApiResponse<Theatre>.Success(theatre);
            } 
            catch (Exception ex) {
                return ApiResponse<Theatre>.Failure(ex.Message);
            }
        }

        [HttpGet]
        [Route("getTheatres")]
        public ApiResponse<IEnumerable<Theatre>> GetTheatres(int id)
        {
            try
            {
                IEnumerable<Theatre> theatres = _theatreService.GetTheatresByMovieId(id);
                return ApiResponse<IEnumerable<Theatre>>.Success(theatres);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Theatre>>.Failure(ex.Message);
            }
        }
    }
}
