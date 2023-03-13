using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.Storage.Azure;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAzureStorage azureStorage;

        public BrandService(IMapper mapper, IUnitOfWork unitOfWork,IAzureStorage azureStorage)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.azureStorage = azureStorage;
        }

        public async Task<IList<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<Brand>().GetAllAsync();
            var map = mapper.Map<BrandDto, Brand>(brands);
            return map;
        }
        public async Task CreateBrandAsync(CreateBrandCommandRequest request)
        {
            Brand brand = new()
            {
                Name = request.Name,
                Picture = request.Picture.Name
            };



            await unitOfWork.GetRepository<Brand>().AddAsync(brand);
            await unitOfWork.SaveAsync();

        }
    }
}
