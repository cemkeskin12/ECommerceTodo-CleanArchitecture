using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Basket : EntityBase
    {
        public Basket()
        {

        }
        public Basket(Guid productId,Guid userId,double quantity,BasketStatus status,decimal totalAmount)
        {
            ProductId = productId;
            UserId = userId;
            Quantity = quantity;
            BasketStatus = status;
            TotalAmount = totalAmount;
        }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public double Quantity { get; set; }
        public BasketStatus BasketStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
