using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Features.Images.Dtos;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.Storage.Azure;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Drawing;
using Image = ECommerce.Domain.Entities.Image;

namespace ECommerce.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAzureStorage azureStorage;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IAzureStorage azureStorage)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.azureStorage = azureStorage;
        }
        public async Task<IList<GetAllProductDto>> GetAllProductsAsync(int currentPage, int pageSize)
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllByPagingAsync(currentPage: currentPage, pageSize: pageSize,
                include: i => i.Include(s => s.Subcategory).Include(b => b.Brand).Include(x => x.Images));

            mapper.Map<SubcategoryDto, Subcategory>(new Subcategory()); //Mapping for include property (subcategory) on products
            mapper.Map<BrandDto, Brand>(new Brand()); //Mapping for include property (brand) on products
            mapper.Map<ImageDto, Image>(new Image()); //Mapping for include property (images) on products

            var result = mapper.Map<GetAllProductDto, Product>(products);
            return result;
        }
        public async Task<GetProductByIdDto> GetProductByIdAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => x.Id == id, include: i => i.Include(s => s.Subcategory).Include(b => b.Brand).Include(r => r.Ratings));

            mapper.Map<SubcategoryDto, Subcategory>(new Subcategory()); //Mapping for include property (subcategory) on products
            mapper.Map<BrandDto, Brand>(new Brand()); //Mapping for include property (brand) on products

            var attributes = await unitOfWork.GetRepository<Domain.Entities.Attribute>()
                .GetAllAsync(x => x.ProductAttributes.Any(x => x.ProductId == product.Id), include: i => i.Include(p => p.ProductAttributes).Include(a => a.AttributeValues));

            List<AttributeValue> attributeValues = new();
            foreach (var item in attributes)
            {
                var values = await unitOfWork.GetRepository<AttributeValue>().GetAsync(x => x.AttributeId == item.Id);
                attributeValues.Add(values);
            }


            var ratings = await unitOfWork.GetRepository<Rating>().GetAllAsync(x => x.ProductId == product.Id, include: i => i.Include(u => u.User));


            var map = mapper.Map<GetProductByIdDto, Product>(product);
            map.AttributeValues = attributeValues;
            map.Ratings = ratings;

            return map;
        }
        public async Task CreateProductAsync(CreateProductCommandRequest request)
        {
            var product = new Product() { Name = request.Name, Description = "asdasd", Price = request.Price, BrandId = request.BrandId, SubcategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69") };

            if (request.Photos != null)
            {
                List<(string fileName, string pathOrContainer)> list = await azureStorage.UploadManyAsync(product.Id, "images", request.Photos);
                if (list != null)
                    foreach (var photo in list)
                        product.Images.Add(new Domain.Entities.Image()
                        {
                            Path = photo.pathOrContainer,
                            FileName = photo.fileName,
                            ProductId = product.Id,
                            StorageType = (byte)Domain.Enums.StorageType.Azure
                        });
            }


            await unitOfWork.GetRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
        }
    }
}
