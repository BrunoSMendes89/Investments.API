using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class PostProductHandler : IRequestHandler<PostProductRequest, string>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PostProductHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task<string> Handle(PostProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _sqlContext.Add(product);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return HelpersClass.SavedSuccess(product.ProductId);
        }
    }
}
