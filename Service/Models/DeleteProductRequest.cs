using MediatR;

namespace Service.Models
{
    public class DeleteProductRequest : IRequest<string>
    {
        public int ProductId { get; set; }
    }
}
