using ECommerce.Application.Features.Subcategories.Queries.GetAllSubcategories;
using ECommerce.Client.Helpers;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Client.ViewComponents
{
    public class HomeHeaderViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public HomeHeaderViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            List<Cart> cartList = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            ViewBag.Quantity = cartList == null ? 0 : cartList.Count;
            return View();
        }
    }
}
