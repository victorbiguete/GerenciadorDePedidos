using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Commands.Order;
using MyStore.Application.Commands.Order.DeleteOrder;
using MyStore.Application.Commands.Order.UpdateOrderStatus;
using MyStore.Application.Queries.Order.GetAllOrder;
using MyStore.Application.Queries.Order.GetAllOrderStatus;
using MyStore.Application.Queries.Order.GetById;
using MyStore.Communication.Response;

namespace MyStore.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : MyStoreBaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register/")]
        [ProducesResponseType(typeof(ResponseOrderRegisterJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterOrder([FromBody]RegisterOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [Route("GetAllOrderStatus/{status}")]
        [ProducesResponseType(typeof(ResponseOrdersJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOrderStatus([FromRoute]int status)
        {
            var result = await _mediator.Send(new GetAllOrderStatusQuerie()
            {
                Id = status
            });

            if(result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllOrder/")]
        [ProducesResponseType(typeof(ResponseOrdersJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOrderStatus()
        {
            var result = await _mediator.Send(new GetAllOrderQuerie());

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var result = await _mediator.Send(new GetByIdQuerie()
            {
                Id = id
            });
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateOrderStatus/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] ResponseOrderUpdateStatusJson request)
        {
            await _mediator.Send(new UpdateOrderStatusCommands()
            {
                Id = request.Id,
                Status = (Domain.Enum.OrderStatus)request.Status
            });

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            await _mediator.Send(new DeleteOrderCommands()
            {
                Id = id
            });

            return Ok();
        }
    }
}
