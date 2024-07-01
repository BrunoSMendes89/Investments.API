using Domain.Entities;
using MediatR;

namespace Service.Models
{
    public class PostUserRequest : IRequest<User>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
