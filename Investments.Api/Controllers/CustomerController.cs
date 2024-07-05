using Bases.Controllers;
using Domain.Enums;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Collections.Generic;
using System.Net;

namespace Investments.Api.Controllers
{
    public class CustomerController : BaseController<CustomerController>
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut("balance/{customerId}")]
        [ProducesResponseType(typeof(CustomerModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreaterCustomer(int customerId, TransactionTypeEnum transactionType, double amount)
        {
            return await CreateActionResult(new PutBalanceRequest { CustomerId = customerId, Amount = amount, TransactionType = transactionType});
        }

        [HttpGet("transactions/{customerId}")]
        [ProducesResponseType(typeof(List<TransactionModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTransactions(int customerId)
        {
            return await CreateActionResult(new GetTransactionsRequest { CustomerId = customerId});
        }
    }
}
