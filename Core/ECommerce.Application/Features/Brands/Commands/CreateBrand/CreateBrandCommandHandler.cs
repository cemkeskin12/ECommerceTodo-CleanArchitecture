using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest>
    {
        private readonly IBrandService brandService;

        public CreateBrandCommandHandler(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await brandService.CreateBrandAsync(request);
            return await Task.FromResult(Unit.Value);
        }
    }
}
