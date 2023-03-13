using ECommerce.Application.Features.Subcategories.Queries.GetAllSubcategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Client.ViewComponents
{
    public class HomeCategoriesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public HomeCategoriesViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IList<GetAllSubcategoriesQueryResponse> response = await mediator.Send(new GetAllSubcategoriesQueryRequest());

            return View(response);
        }
    }
}
