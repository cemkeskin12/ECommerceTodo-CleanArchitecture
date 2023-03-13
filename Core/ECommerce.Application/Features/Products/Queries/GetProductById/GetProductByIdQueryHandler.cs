using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductService productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {

            var product = await productService.GetProductByIdAsync(request.Id);
            return new()
            {
                GetProductByIdDto = product
            };
        }
    }
}
