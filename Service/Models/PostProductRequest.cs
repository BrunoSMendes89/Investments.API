﻿using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Service.Models
{
    public class PostProductRequest : IRequest<ProductModel>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
    }
}
