using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Security.Claims;

namespace ECommerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly string userId;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task CreateOrder(CreateOrderCommandRequest orderCommand)
        {

            IList<decimal> productPrices = new List<decimal>();
            foreach (var item in orderCommand.CreateOrderDtos)
            {
                var product = await unitOfWork.GetRepository<Product>().GetAsync(x => x.Id == item.ProductId);
                productPrices.Add(product.Price * item.ProductCount);

            }

            var order = new Order(Guid.Parse(userId), OrderType.Received, productPrices.Sum());
            await unitOfWork.GetRepository<Order>().AddAsync(order);

            foreach (var product in orderCommand.CreateOrderDtos)
            {
                var orderProducts = new OrderProduct(order.Id, product.ProductId);
                await unitOfWork.GetRepository<OrderProduct>().AddAsync(orderProducts);
            }

            await unitOfWork.SaveAsync();
        }
    }
}
