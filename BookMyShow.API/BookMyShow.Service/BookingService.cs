using BookMyShow.Data.IRepositories;
using BookMyShow.DomainModels;
using BookMyShow.Services.Contracts;

namespace BookMyShow.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public BookingRequest BookMovie(BookingRequest bookingRequest)
        {
            return _bookingRepository.BookMovie(bookingRequest);
        }
    }
}
