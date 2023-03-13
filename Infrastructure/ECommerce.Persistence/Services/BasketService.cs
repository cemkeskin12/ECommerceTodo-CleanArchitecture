using ECommerce.Application.Features.Baskets.Commands.CreateBasket;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly string userId;
        public BasketService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task CreateBasket(CreateBasketCommandRequest basketCommand)
        {
            var basket = new Basket(basketCommand.ProductId, Guid.Parse(userId), basketCommand.Quantity, basketCommand.BasketStatus, basketCommand.TotalAmount);

            await unitOfWork.GetRepository<Basket>().AddAsync(basket);
            await unitOfWork.SaveAsync();

        }
    }
}
