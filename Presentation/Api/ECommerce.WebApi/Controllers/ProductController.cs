using ECommerce.Application.Attributes;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Application.Features.Products.Queries.GetProductById;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize]
        [HttpGet]
        [MenuDefinition(ActionType = ActionType.Read)]
        public async Task<IActionResult> GetAllProducts(int currentPage = 1, int pageSize = 5)
        {
            GetAllProductsQueryResponse products = await mediator.Send(new GetAllProductsQueryRequest() 
            { 
                CurrentPage = currentPage, PageSize = pageSize
            });
            return Ok(products);
        }
        [Authorize]
        [HttpGet]
        [MenuDefinition(ActionType = ActionType.Read)]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            GetProductByIdQueryResponse product = await mediator.Send(new GetProductByIdQueryRequest() { Id = id });
            return Ok(product);
        }
        [HttpPost]
        [MenuDefinition(ActionType = ActionType.Create)]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductCommandRequest request)
        {
            Unit value = await mediator.Send(request);
            return Ok(value);
        }
    }
}
