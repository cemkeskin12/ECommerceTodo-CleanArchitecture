using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandRequest : IRequest
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public BasketStatus BasketStatus { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
