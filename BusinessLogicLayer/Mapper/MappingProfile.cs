using AutoMapper;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();
            //CreateMap<CategoryDTO, Category>();

        }
    }
}
