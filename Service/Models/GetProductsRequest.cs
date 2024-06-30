using Domain.Enums;
using MediatR;

namespace Service.Models
{
    public class GetProductsRequest : IRequest<List<GetProductsResponse>>
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public ProductTypeEnum? ProductType { get; set; }
    }
}
