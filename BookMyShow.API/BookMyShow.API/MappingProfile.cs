using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.DomainModels;

namespace BookMyShow.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DomainModels.Movie, Data.DataModels.Movie>().ReverseMap();
            CreateMap<Data.DataModels.Theatre, DomainModels.Theatre>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => src.MovieIds.
                Split(',', StringSplitOptions.None).Select(int.Parse).ToList()))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowTime.
                Split(',', StringSplitOptions.None).Select(TimeOnly.Parse).ToList()));
            CreateMap<Ticket, BookingRequest>()
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src =>
                src.SeatNumbers.Split(',', StringSplitOptions.None).ToList()));
            CreateMap<BookingRequest, Ticket>()
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => String.Join(",", src.SeatNumbers)));
            CreateMap<ReservedSeat, ReserveSeat>().ReverseMap();
            CreateMap<Data.DataModels.User, DomainModels.User>().ReverseMap();
        }
    }
}
