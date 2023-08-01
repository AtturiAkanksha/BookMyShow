using AutoMapper;
using BookMyShowWeb.DTOs;
using Data.DataModels;
using DomainModels;

namespace BookMyShowWeb
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingRequest, BookedShow>().ForMember(dest => dest.SeatNames, opt => opt.MapFrom(src => string.Join(",", src.SeatNames))).ReverseMap();
            CreateMap<BookedShow, BookingRequest>().ForMember(dest => dest.SeatNames, opt => opt.MapFrom(src => ParseStringToIntList(src.SeatNames)));
            CreateMap<DomainModels.Movie, Data.DataModels.Movie>().ReverseMap();
            CreateMap<DomainModels.Theatre, Data.DataModels.Theatre>().ReverseMap();
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
