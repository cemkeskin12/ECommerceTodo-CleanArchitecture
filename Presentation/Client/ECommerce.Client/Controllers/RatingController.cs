using ECommerce.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Client.Controllers
{
    public class RatingController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RatingController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
