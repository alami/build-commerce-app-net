using API.Dtos;
using AutoMapper;
using Core.Models.Billing;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>();
        }        
    }
}
