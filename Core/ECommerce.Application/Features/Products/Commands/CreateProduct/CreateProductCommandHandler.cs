using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IProductService productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            await productService.CreateProductAsync(request);

            return await Task.FromResult(Unit.Value);
        }
    }
}
