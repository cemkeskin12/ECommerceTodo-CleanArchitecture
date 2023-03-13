using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Auth.Commands.EmailConfirmation;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [MenuDefinition( ActionType = ActionType.Read)]
        public async Task<IActionResult> Login([FromQuery]LoginCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Create)]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Update)]
        public async Task<IActionResult> EmailConfirmation(EmailConfirmationCommandRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
