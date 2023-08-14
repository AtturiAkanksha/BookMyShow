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
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => ParseStringToIntList(src.MovieIds)))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => StringToTimeOnly(src.ShowTime)));
            CreateMap<Ticket, BookingRequest>()
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => ParseStringToStringList(src.SeatNumbers)));
            CreateMap<BookingRequest, Ticket>()
                .ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => String.Join(",", src.SeatNumbers)));
            CreateMap<ReservedSeat, ReserveSeat>().ReverseMap();
        }

        private List<int> ParseStringToIntList(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
            {
                return new List<int>();
            }
            return numbersString.Split(',').Select(str => int.TryParse(str, out int number) ? number : 0).ToList();
        }

        private List<string> ParseStringToStringList(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return new List<string>();
            }
            return data.Split(',').ToList();
        }

        private List<TimeOnly> StringToTimeOnly(string timeString)
        {
            if (string.IsNullOrEmpty(timeString))
            {
                return new List<TimeOnly>();
            }
            return timeString.Split(',').Select(str => TimeOnly.TryParse(str, out TimeOnly time) ? time : default).ToList();
        }


    }
}
