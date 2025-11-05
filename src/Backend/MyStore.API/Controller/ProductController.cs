using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Queries.Product.GetAllAsync;
using MyStore.Application.Queries.Product.GetByIdAsync;
using MyStore.Communication.Response;

namespace MyStore.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : MyStoreBaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseProductsJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _mediator.Send(new GetAllAsyncQuerie());

            if(products is null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(ResponseShortProductJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var product = await _mediator.Send(new GetByIdProductQuerie()
            {
                Id = id 
            });

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
