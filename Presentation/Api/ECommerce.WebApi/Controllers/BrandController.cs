using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Features.Brands.Queries;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [MenuDefinition(ActionType = ActionType.Read)]
        public async Task<IActionResult> GetAllBrands()
        {
            IList<BrandDto> list = await mediator.Send(new GetAllBrandsQuery());
            return Ok(list);
        }
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Create)]
        public async Task<IActionResult> CreateBrand([FromForm]CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
