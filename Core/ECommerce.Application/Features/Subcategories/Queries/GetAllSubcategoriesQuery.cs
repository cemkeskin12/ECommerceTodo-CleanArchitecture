using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Subcategories.Queries
{
    public class GetAllSubcategoriesQuery : IRequest<IList<SubcategoryDto>>
    {
        public class GetAllSubcategoriesQueryHandler : IRequestHandler<GetAllSubcategoriesQuery, IList<SubcategoryDto>>
        {
            private readonly ISubcategoryService subcategoryService;

            public GetAllSubcategoriesQueryHandler(ISubcategoryService subcategoryService)
            {
                this.subcategoryService = subcategoryService;
            }
            public async Task<IList<SubcategoryDto>> Handle(GetAllSubcategoriesQuery request, CancellationToken cancellationToken)
            {
                return await subcategoryService.GetAllSubcategoriesAsync();
            }
        }
    }
}
