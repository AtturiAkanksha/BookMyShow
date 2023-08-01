using Data.DataModels;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DomainModels.Theatre theatre = _theatreService.GetTheatres(id);
            return Ok(theatre);
        }

        [HttpGet]
        [Route("getReservedSeatsData")]
        public IEnumerable<ReservedSeat> GetReservedSeats()
        {
            return _theatreService.Seats();
        }
    }
}
