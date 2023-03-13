using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Subcategory : EntityBase
    {
        public string? NameTR { get; set; }
        public string? NameEN { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
