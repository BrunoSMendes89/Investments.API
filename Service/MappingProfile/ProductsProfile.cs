﻿using AutoMapper;
using Domain.Entities;
using Service.Models;

namespace Service.MappingProfile
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, GetProductsResponse>();
        }
    }
}
