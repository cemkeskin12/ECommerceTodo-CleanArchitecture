using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Dtos;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<GetAllProductDto>> GetAllProductsAsync(int currentPage, int pageSize);
        Task<GetProductByIdDto> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(CreateProductCommandRequest request);
    }
}
