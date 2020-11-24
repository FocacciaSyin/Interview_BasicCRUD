using AutoMapper;
using Interview_BasicCRUD.Dto;
using Interview_BasicCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPrice ?? 1))
                )
                .ForMember(
                dest => dest.DB_CRDAT,
                opt => opt.MapFrom(src => src.DB_CRDAT.ToString("yyyy-MM-dd HH:MM:ss"))
                );


            CreateMap<ProductForCreateDto, Product>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                dest => dest.DB_CRDAT,
                opt => opt.MapFrom(src => DateTime.Now)
                );


            CreateMap<ProductForUpdateDto, Product>()
                .ForMember(
                dest => dest.DB_TRDAT,
                opt => opt.MapFrom(src => DateTime.Now)
                );

        }
    }
}
