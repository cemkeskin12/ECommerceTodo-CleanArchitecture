using ECommerce.Application.Features.Baskets.Commands.CreateBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IBasketService
    {
        Task CreateBasket(CreateBasketCommandRequest basketCommand);
    }
}
