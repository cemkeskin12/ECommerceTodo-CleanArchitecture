using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Dtos;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IBrandService
    {
        Task<IList<BrandDto>> GetAllBrandsAsync();
        Task CreateBrandAsync(CreateBrandCommandRequest request);
    }
}
