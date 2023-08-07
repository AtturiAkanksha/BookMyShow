using BookMyShow.DomainModels;

namespace BookMyShow.Services.Contracts
{
    public interface IBookingService
    {
        BookingRequest BookMovie(BookingRequest bookingRequest);
    }
}
