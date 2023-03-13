using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Client.ViewComponents
{
    public class HomeBrandsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public HomeBrandsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IList<GetAllBrandsQueryResponse> response = await mediator.Send(new GetAllBrandsQueryRequest());
            return View(response);
        }
    }
}
