using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task CreateRolesAsync(IEnumerable<string> roleNames)
        {
            Role role = new();
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    role.Id = Guid.NewGuid();
                    role.Name = roleName;
                    role.ConcurrencyStamp = Guid.NewGuid().ToString();
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
