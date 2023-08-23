using BookMyShow.DomainModels;

namespace BookMyShow.Data.IRepositories
{
    public interface IBookingRepository
    {
        BookingRequest BookMovie(BookingRequest bookingRequest);
    }
}
