﻿using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class PutProductHandler : IRequestHandler<PutProductRequest, ProductModel>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PutProductHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<ProductModel> Handle(PutProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _sqlContext.Product.FirstOrDefaultAsync(p => p.ProductId == request.ProductId,cancellationToken);
            if (product == null)
                throw new PreconditionFailedException();

            request.Quantity += product.Quantity;
            product = _mapper.Map(request, product); 

            _sqlContext.Update(product);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductModel>(product);
        }
    }
}
