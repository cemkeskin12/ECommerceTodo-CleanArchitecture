using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Services
{
    public class UserService : IUserService
    {
        public Task<User> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAllUsersWithRolesAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
