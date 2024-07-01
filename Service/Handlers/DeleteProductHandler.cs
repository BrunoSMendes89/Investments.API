using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, string>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public DeleteProductHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _sqlContext.Product.FirstOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken);

            product.Active = false;
            _sqlContext.Update(product);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return HelpersClass.UpdatedSuccess(product.ProductId);
        }
    }
}
