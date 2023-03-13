using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> GetAllUsersWithRolesAsync(Guid roleId);
    }
}
