using Bases.Email;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class SendEmailHandler : IRequestHandler<SendEmailNotification, Unit>
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlContext _sqlContext;

        public SendEmailHandler(IConfiguration configuration, MySqlContext sqlContext)
        {
            _configuration = configuration;
            _sqlContext = sqlContext;
        }

        public async Task<Unit> Handle(SendEmailNotification request, CancellationToken cancellationToken)
        {
            var users = await _sqlContext.User.Where(u => u.Email != null && u.Active == true).ToListAsync();
            var products = await _sqlContext.Product.Where(p => p.DueDate >= DateTime.Today && p.DueDate <= DateTime.Today.AddDays(5)).ToListAsync(); 
            foreach(var email in users)
            {
                await EmailNotification.Send(email.Email,email.UserName,products,_configuration);
            }
            return Unit.Value;
        }
    }
}
