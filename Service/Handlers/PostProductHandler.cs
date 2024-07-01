using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class PostProductHandler : IRequestHandler<PostProductRequest, ProductModel>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PostProductHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task<ProductModel> Handle(PostProductRequest request, CancellationToken cancellationToken)
        {
            request.Name.ToUpper();
            var product = _mapper.Map<Product>(request);
            product.Active = true;
            _sqlContext.Add(product);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductModel>(product);
        }
    }
}
