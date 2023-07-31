using AutoMapper;
using BookMyShowAPI.DTOs;
using Data.DataModels;
using DomainModels;

namespace BookMyShowAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingRequest, BookedShows>().ForMember(dest => dest.SeatNames, opt => opt.MapFrom(src => string.Join(",", src.SeatNames))).ReverseMap();
            CreateMap<BookedShows, BookingRequest>().ForMember(dest => dest.SeatNames, opt => opt.MapFrom(src => ParseStringToIntList(src.SeatNames)));
            CreateMap<DomainModels.Movies, Data.DataModels.Movies>().ReverseMap();
            CreateMap<DomainModels.Theatres, Data.DataModels.Theatres>().ReverseMap();
            CreateMap<BookingRequestDTO, BookingRequest>().ReverseMap();
        }

        private List<int> ParseStringToIntList(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
            {
                return new List<int>();
            }
            return numbersString.Split(',').Select(str => int.TryParse(str, out int number) ? number : 0).ToList();
        }
    }
}
