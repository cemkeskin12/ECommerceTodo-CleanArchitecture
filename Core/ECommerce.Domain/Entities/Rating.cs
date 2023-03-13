using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Rating : EntityBase
    {
        public int Rate { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
