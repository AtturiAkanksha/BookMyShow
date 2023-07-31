using DomainModels;

namespace Service.Contracts
{
    public interface IBookingService
    {
         Task<BookingRequest> BookMovie(BookingRequest bookingRequest);
    }
}
