using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public Order(Guid userId, OrderType orderType,decimal totalAmount)
        {
            UserId = userId;
            OrderType = orderType;
            TotalAmount = totalAmount;
            OrderProducts = new HashSet<OrderProduct>();
        }

        public Guid UserId { get; set; }
        public OrderType OrderType { get; set; }
        public decimal TotalAmount { get; set; } 
        public User User { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
