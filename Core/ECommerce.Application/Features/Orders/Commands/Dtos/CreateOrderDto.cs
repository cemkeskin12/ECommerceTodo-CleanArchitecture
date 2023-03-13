using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.Dtos
{
    public class CreateOrderDto
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
