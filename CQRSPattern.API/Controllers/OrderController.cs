using CQRSPattern.Application.CQRS.Command;
using CQRSPattern.Application.CQRS.Handler;
using CQRSPattern.Application.CQRS.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _mediator.Send(new GetOrderByIdQuery(id)));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllOrdersQuery()));
    }
}
