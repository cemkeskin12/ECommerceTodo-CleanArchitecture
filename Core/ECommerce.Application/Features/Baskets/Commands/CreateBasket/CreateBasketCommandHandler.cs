using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest>
    {
        private readonly IBasketService basketService;

        public CreateBasketCommandHandler(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        public async Task<Unit> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await basketService.CreateBasket(request);
            return await Task.FromResult(Unit.Value);
        }
    }
}
