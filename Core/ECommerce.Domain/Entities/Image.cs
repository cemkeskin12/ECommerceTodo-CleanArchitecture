using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Image : EntityBase
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public byte StorageType { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
