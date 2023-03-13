using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Create)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
