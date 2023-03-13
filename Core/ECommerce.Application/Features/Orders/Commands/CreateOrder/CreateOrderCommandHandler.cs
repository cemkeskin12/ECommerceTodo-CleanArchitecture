using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest>
    {
        private readonly IOrderService orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await orderService.CreateOrder(request);
            return await Task.FromResult(Unit.Value);
        }
    }
}
