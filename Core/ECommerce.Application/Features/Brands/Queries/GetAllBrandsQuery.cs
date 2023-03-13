using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Brands.Queries
{
    public class GetAllBrandsQuery : IRequest<IList<BrandDto>>
    {
        public class GetAllBrandsQueryHandle : IRequestHandler<GetAllBrandsQuery, IList<BrandDto>>
        {
            private readonly IBrandService brandService;

            public GetAllBrandsQueryHandle(IBrandService brandService)
            {
                this.brandService = brandService;
            }
            public async Task<IList<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
            {
                return await brandService.GetAllBrandsAsync();
            }
        }
    }
}
