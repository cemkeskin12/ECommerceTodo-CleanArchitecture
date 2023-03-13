using ECommerce.Application.Features.Orders.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest
    {
        public IList<CreateOrderDto> CreateOrderDtos { get; set; }
    }
}
