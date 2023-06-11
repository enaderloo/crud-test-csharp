using Core.Api.Controllers;
using Mc2.CrudTest.Application.Commands.Customers;
using Mc2.CrudTest.Application.Queries.Customers;
using Mc2.CrudTest.Application.ViewModels.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mc2.CrudTest.Api.Controllers
{
    public class CustomerController : BaseControllerWitoutAuthentication
    {
        private readonly ICustomerQueries _queries;

        public CustomerController(IMediator mediator, ICustomerQueries customerQueries) : base(mediator)
        {
            _queries = customerQueries ?? throw new ArgumentNullException(nameof(customerQueries));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerDto>> CreateAsync([FromBody] CreateCustomerCommand command)
        {
            return Ok(await Send(command));
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAsync(long id, [FromBody] UpdateCustomerCommand command)
        {
            var commandResult = await Send(id, command);
            return Ok(commandResult);
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Delete(long id, [FromQuery] long timeStamp)
        {
            var commandResult = await Send(id, new DeleteCustomerCommand(timeStamp));
            if (commandResult)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedCustomerSummary), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedCustomerSummary>> GetAll([FromQuery] CustomerFilter customerFilter)
        {
            return Ok(await _queries.GetsAsync(customerFilter));
        }
    }
}
