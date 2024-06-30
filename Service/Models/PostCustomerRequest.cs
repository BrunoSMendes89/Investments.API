using MediatR;

namespace Service.Models
{
    public class PostCustomerRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public double AccountBalance { get; set; }
    }
}
