using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using AutoMapper;
using DomainModels;

namespace BookMyShowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("BookMovie")]
        public IActionResult BookMovie([FromBody] BookingRequest bookingRequest)
        {
            try
            {
                return Ok(_bookingService.BookMovie(bookingRequest));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
