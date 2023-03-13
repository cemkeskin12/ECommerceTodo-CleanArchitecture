using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task CreateRolesAsync(IEnumerable<string> roleNames);
    }
}
