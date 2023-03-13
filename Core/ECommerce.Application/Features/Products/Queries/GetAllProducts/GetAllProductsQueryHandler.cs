using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductService productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await productService.GetAllProductsAsync(request.CurrentPage, request.PageSize);
            return new()
            {
                GetAllProductDtos = products
            };
        }
    }
}
