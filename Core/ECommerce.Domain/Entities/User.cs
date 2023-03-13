using Microsoft.AspNetCore.Identity;

namespace ECommerce.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Picture { get; set; }

    }
}
