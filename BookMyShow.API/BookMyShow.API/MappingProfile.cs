using AutoMapper;
using BookMyShow.Data.DataModels;
using BookMyShow.DomainModels;

namespace BookMyShow.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingRequest, BookedShow>().ForMember(dest => dest.SeatNames, opt => opt.MapFrom(src => string.Join(",", src.SeatNumbers)));



            CreateMap<BookedShow, BookingRequest>().ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => ParseStringToIntList(src.SeatNames)));
            CreateMap<Data.DataModels.Theatre, DomainModels.Theatre>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => ParseStringToIntList(src.MovieIds)))
                .ForMember(dest => dest.MovieTimings, opt => opt.MapFrom(src => StringToTimeOnly(src.MovieTimings)));
            CreateMap<DomainModels.Movie, Data.DataModels.Movie>().ReverseMap();
            CreateMap<DomainModels.ReservedSeat, Data.DataModels.ReserveSeat>().ReverseMap();
        }

        private List<int> ParseStringToIntList(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
            {
                return new List<int>();
            }
            return numbersString.Split(',').Select(str => int.TryParse(str, out int number) ? number : 0).ToList();
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
