using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Roles.Commands.CreateRole;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /*
        Otomatik olarak tüm atanabilecek rolleri bulur. Sadece çalıştırılması yeterlidir.
        
        MenuDefinition ile işaretlenmiş tüm Controller, Action, ActionType ve HttpType değerlerini otomatik getirir.
        */
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Create)]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            return Ok(await mediator.Send(command));

        }
    }
}
