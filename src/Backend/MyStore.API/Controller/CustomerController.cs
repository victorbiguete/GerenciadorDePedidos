using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Queries.Customer.GetAllAsync;
using MyStore.Application.Queries.Customer.GetByIdAsync;
using MyStore.Communication.Response;

namespace MyStore.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : MyStoreBaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseCustomersJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllAsyncQuery());

            if (customers is null)
                return NotFound();

            return Ok(customers);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(ResponseShortCustomerJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var customer = await _mediator.Send(new GetByIdAsyncQuerie()
            {
                Id = id
            });

            if(customer is null)
                return NotFound();

            return Ok(customer);
        }
    }
}
