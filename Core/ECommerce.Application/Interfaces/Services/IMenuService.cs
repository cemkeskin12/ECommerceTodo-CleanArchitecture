using ECommerce.Domain.Config;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenuDefinitionEndPoints(string assemblyName);
    }
}
