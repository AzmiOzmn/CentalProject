using AutoMapper;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, InsertFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}
