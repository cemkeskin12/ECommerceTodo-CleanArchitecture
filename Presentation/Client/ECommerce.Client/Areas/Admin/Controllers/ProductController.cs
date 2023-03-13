using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Application.Interfaces.Storage.Azure;
using ECommerce.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Client.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            IList<GetAllProductsQueryResponse> list = await mediator.Send(new GetAllProductsQueryRequest());
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
			IList<GetAllBrandsQueryResponse> brands = await mediator.Send(new GetAllBrandsQueryRequest());

            return View(new CreateProductCommandRequest
            {
                Brands = brands
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest commandRequest)
        {
            await mediator.Send(commandRequest);
            
            return RedirectToAction("Index","Product",new {Area = "Admin"});
        }
    }
}
