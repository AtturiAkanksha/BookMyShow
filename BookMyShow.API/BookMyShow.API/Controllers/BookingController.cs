using Microsoft.AspNetCore.Mvc;
using BookMyShow.Services.Contracts;
using BookMyShow.DomainModels;
using BookMyShow.API.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;

namespace BookMyShow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("bookMovie")]
        public ApiResponse<BookingRequest> BookMovie([FromBody] BookingRequest bookingRequest)
        {
            try
            {
                BookingRequest movie = _bookingService.BookMovie(bookingRequest);
                return ApiResponse<BookingRequest>.Success(movie);
            }
            catch (Exception ex)
            {
                return ApiResponse<BookingRequest>.Failure(ex.Message);
            }
        }
    }
}
