using AutoMapper;
using Domain.Entities;
using Service.Models;

namespace Service.MappingProfile
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<PostUserRequest, User>();
        }
    }
}
