using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class PostUserHandler : IRequestHandler<PostUserRequest, User>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PostUserHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task<User> Handle(PostUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _sqlContext.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
                throw new PreconditionFailedException("This email already exists.");
            user = _mapper.Map<User>(request);
            user.Active = true;
            _sqlContext.Add(user);
            await _sqlContext.SaveChangesAsync();
            return user;
        }
    }
}
