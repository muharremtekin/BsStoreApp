using AutoMapper;
using Entities.DataTransferObjects.Fault;
using Entities.DataTransferObjects.Image;
using Entities.DataTransferObjects.Product;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForInsertion, Product>();

            CreateMap<FaultDtoForUpdate, Fault>().ReverseMap();
            CreateMap<Fault, FaultDto>();
            CreateMap<FaultDtoForInsertion, Fault>();

            CreateMap<ImageDtoForUpdate, Image>().ReverseMap();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDtoForInsertion, Image>();
        }
    }
}
