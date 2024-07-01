using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, List<GetProductsResponse>>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public GetProductsHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<List<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != null && request.Id > 0)
            {
                var byId = await _sqlContext.Product.FirstOrDefaultAsync(p => p.ProductId == request.Id, cancellationToken);
                return new List<GetProductsResponse> { _mapper.Map<GetProductsResponse>(byId) };
            }

            var query = _sqlContext.Product.Take(15).AsQueryable();

            if (!string.IsNullOrEmpty(request.Description))
            {
                var searchValue = request.Description.Trim().ToUpper()
                                                     .Replace("-","")
                                                     .Replace(".","")
                                                     .Replace("=","");
                query = query.Where(b => b.Name.ToUpper().Contains(searchValue));
            }

            if (request.ProductType > 0)
            {
                var productType = request.ProductType;
                query = query.Where(b => b.ProductType == productType);
            }

            var products = await query.ToListAsync(cancellationToken);
            var response = _mapper.Map<List<GetProductsResponse>>(products);
            return response;
        }
    }
}
