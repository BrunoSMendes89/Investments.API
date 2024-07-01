using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Service.Models;

namespace Service.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<PostCustomerRequest,Customer>();
            CreateMap<PutBalanceRequest,Customer>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<Transaction, TransactionModel>();
        }
    }
}
