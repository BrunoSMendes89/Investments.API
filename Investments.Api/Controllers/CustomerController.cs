using Bases.Controllers;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Net;

namespace Investments.Api.Controllers
{
    public class CustomerController : BaseController<CustomerController>
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut("balance/{customerId}")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreaterCustomer(int customerId, TransactionTypeEnum transactionType, double amount)
        {
            return await CreateActionResult(new PutBalanceRequest { CustomerId = customerId, Amount = amount, TransactionType = transactionType});
        }
    }
}
