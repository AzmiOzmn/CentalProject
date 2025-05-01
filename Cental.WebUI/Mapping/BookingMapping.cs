using AutoMapper;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, InsertBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
