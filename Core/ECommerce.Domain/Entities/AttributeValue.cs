using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class AttributeValue : EntityBase, IEntityBase
    {
        public string? ValueTR { get; set; }
        public string? ValueEN { get; set; }
        public Guid AttributeId { get; set; }
        public Domain.Entities.Attribute Attribute { get; set; }
    }
}
