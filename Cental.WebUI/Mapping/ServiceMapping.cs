using AutoMapper;
using Cental.DtoLayer.ServiceDto;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ServiceMapping : Profile 
    {
        public ServiceMapping()
        {
                CreateMap<Service,ResultServiceDto>().ReverseMap();
                CreateMap<Service,UpdateServiceDto>().ReverseMap();
                CreateMap<Service,InsertServiceDto>().ReverseMap();
        }
    }
}
