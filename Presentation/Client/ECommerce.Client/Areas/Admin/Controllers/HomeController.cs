using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using ECommerce.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
