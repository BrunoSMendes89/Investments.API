using Domain.Models;
using MediatR;

namespace Service.Models
{
    public class PostCustomerRequest : IRequest<CustomerModel>
    {
        public string Name { get; set; }
        public double AccountBalance { get; set; }
    }
}
