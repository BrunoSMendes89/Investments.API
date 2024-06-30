using AutoMapper;
using Domain.Entities;
using Service.Models;

namespace Service.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<PostCustomerRequest,Customer>();
        }
    }
}
