using AutoMapper;
using YoutubeApi.Application.DTOs;
using YoutubeApi.Application.Features.Products.Queries.GetAllProducts;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Common.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetAllProductsQueryResponse>()
                .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                .ForMember(dest => dest.Discount, src => src.MapFrom(x => (decimal?)x.Discount))
                .ForMember(dest => dest.Brand, src => src.MapFrom(x => x.Brand))
                .ReverseMap();

            CreateMap<Brand, BrandDto>()
                .ReverseMap();
        }
    }
}



