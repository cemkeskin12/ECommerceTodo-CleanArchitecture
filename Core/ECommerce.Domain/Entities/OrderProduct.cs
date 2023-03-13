using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class OrderProduct : IEntityBase
    {
        public OrderProduct()
        {
            Order = new Order();
        }
        public OrderProduct(Guid orderId,Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
