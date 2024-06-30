﻿using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class PostCustomerHandler : IRequestHandler<PostCustomerRequest, Unit>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PostCustomerHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PostCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.AccountNumber = GenerateAccountNumber();
            _sqlContext.Add(customer);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public static string GenerateAccountNumber()
        {
            Random random = new Random();
            int part1 = random.Next(1000, 9999);
            int part2 = random.Next(0, 10);
            return $"{part1}-{part2}";
        }
    }
}
