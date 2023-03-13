using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class UserFavorite : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
