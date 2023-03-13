using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderCommandRequest orderCommand);
    }
}
