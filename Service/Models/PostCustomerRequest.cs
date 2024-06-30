using MediatR;

namespace Service.Models
{
    public class PostCustomerRequest : IRequest<string>
    {
        public string Name { get; set; }
        public double AccountBalance { get; set; }
    }
}
