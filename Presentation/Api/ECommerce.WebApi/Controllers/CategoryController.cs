using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Application.Features.Subcategories.Queries;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]

        [MenuDefinition(ActionType = ActionType.Read)]
        public async Task<IActionResult> GetAllSubcategories()
        {
            IList<SubcategoryDto> list = await mediator.Send(new GetAllSubcategoriesQuery());
            return Ok(list);
        }
    }
}
