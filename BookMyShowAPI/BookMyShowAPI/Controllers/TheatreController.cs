using Data.DataModels;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService _theatreService;
        private readonly IReservedSeatsService _seatsService;

        public TheatreController(ITheatreService theatreService, IReservedSeatsService seatsService)
        {
            _theatreService = theatreService;
            _seatsService = seatsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DomainModels.Theatres theatre = _theatreService.GetTheatres(id);
            return Ok(theatre);
        }

        [HttpGet]
        [Route("getReservedSeatsData")]
        public IEnumerable<ReservedSeats> GetReservedSeats()
        {
            return _seatsService.GetAll();
        }
    }
}
