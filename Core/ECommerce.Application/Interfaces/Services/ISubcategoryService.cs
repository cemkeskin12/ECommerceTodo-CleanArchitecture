using ECommerce.Application.Features.Subcategories.Dtos;

namespace ECommerce.Application.Interfaces.Services
{
    public interface ISubcategoryService
    {
        Task<IList<SubcategoryDto>> GetAllSubcategoriesAsync();
    }
}
