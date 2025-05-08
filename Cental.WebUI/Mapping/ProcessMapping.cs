using AutoMapper;
using Cental.DtoLayer.ProcessDtos;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ProcessMapping : Profile
    {
        public ProcessMapping()
        {
            CreateMap<Process, ResultProcessDto>().ReverseMap();
            CreateMap<Process, UpdateProcessDto>().ReverseMap();
            CreateMap<Process, InsertProcessDto>().ReverseMap();
        }
    }
}
