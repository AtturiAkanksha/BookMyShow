using BookMyShowAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using AutoMapper;
using DomainModels;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("BookMovie")]
        public async Task<IActionResult> BookMovie(BookingRequestDTO bookingRequest)
        {
            try
            {
                BookingRequest _bookingRequest = _mapper.Map<BookingRequest>(bookingRequest);
                return Ok(await _bookingService.BookMovie(_bookingRequest));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
