using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Storage.Azure;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ECommerce.Persistence.Test.Services
{
    //public class BrandServiceTests
    //{

    //    private readonly IMapper mapper;
    //    private readonly IUnitOfWork unitOfWork;
    //    private readonly IAzureStorage azureStorage;

    //    public BrandServiceTests()
    //    {
    //        mapper = new Mock<IMapper>().Object;
    //        unitOfWork = new Mock<IUnitOfWork>().Object;
    //        azureStorage = new Mock<IAzureStorage>().Object;
    //    }

    //    [Fact]
    //    public async Task GetAllBrandsAsync_ShouldReturnListOfBrandDtos_WhenCalled()
    //    {
    //        // Arrange
    //        var brands = new List<Brand>
    //        {
    //        new Brand { Name = "Brand 1", Picture = "picture1.jpg" },
    //        new Brand { Name = "Brand 2", Picture = "picture2.jpg" },
    //        };

    //        var mockMapper = mapper.Map<BrandDto, Brand>(brands);

    //        var mockBrandRepository = new Mock<IRepository<Brand>>();
    //        var repo = mockBrandRepository.Setup(repo => repo.GetAllByPagingAsync(null, null, null, 1, 5, true, true, default)).ReturnsAsync(brands);
    //        var mockUnitofwork = new Mock<IUnitOfWork>();
    //        var depo = mockUnitofwork.Setup(uow => uow.GetRepository<Brand>()).Returns(mockBrandRepository.Object);
    //        var brandService = new BrandService(mapper, unitOfWork, azureStorage);

    //        // Act
    //        var result = await brandService.GetAllBrandsAsync();

    //        // Assert
    //        Assert.IsType<List<BrandDto>>(result);
    //        Assert.Equal(2, result.Count);
    //        Assert.Equal("Brand 1", result[0].Name);
    //        Assert.Equal("Brand 2", result[1].Name);
    //    }

    //    [Fact]
    //    public async Task CreateBrandAsync_ShouldAddBrandToRepository_WhenCalled()
    //    {
    //        // Arrange
    //        var mockBrandRepository = new Mock<IRepository<Brand>>();
    //        var mockUnitofwork = new Mock<IUnitOfWork>();
    //        mockUnitofwork.Setup(uow => uow.GetRepository<Brand>()).Returns(mockBrandRepository.Object);
    //        var brandService = new BrandService(mapper, unitOfWork, azureStorage);
    //        var request = new CreateBrandCommandRequest { Name = "New Brand", Picture = new FormFile(null, 0, 0, "picture.jpg", "image/jpeg") };

    //        // Act
    //        await brandService.CreateBrandAsync(request);

    //        // Assert
    //        mockBrandRepository.Verify(repo => repo.AddAsync(It.IsAny<Brand>()), Times.Once);
    //        mockUnitofwork.Verify(uow => uow.SaveAsync(), Times.Once);
    //    }
    //}



    public class BrandServiceTests
    {
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IAzureStorage> azureStorageMock = new Mock<IAzureStorage>();

        private readonly BrandService brandService;

        public BrandServiceTests()
        {
            brandService = new BrandService(mapperMock.Object, unitOfWorkMock.Object, azureStorageMock.Object);
        }

        [Fact]
        public async Task GetAllBrandsAsync_ShouldReturnAllBrands()
        {
            // Arrange
            var brands = new List<Brand>
            {
            new Brand { Id = Guid.NewGuid(), Name = "Brand 1" ,Picture = "asdasd"},
            new Brand { Id = Guid.NewGuid(), Name = "Brand 2" ,Picture = "asdasd"},
            new Brand { Id = Guid.NewGuid(), Name = "Brand 3" ,Picture = "asdasd"}
            };

            unitOfWorkMock.Setup(x => x.GetRepository<Brand>().GetAllAsync(null, null, null, true, default)).ReturnsAsync(brands);

            var brandDtos = brands.Select(x => new BrandDto { Name = x.Name }).ToList();
            mapperMock.Setup(x => x.Map<BrandDto, Brand>(brands, null)).Returns(brandDtos);

            // Act
            var result = await brandService.GetAllBrandsAsync();

            // Assert
            Assert.IsType<List<BrandDto>>(result);
            Assert.Equal(3, result.Count);

            for (int i = 0; i < brands.Count; i++)
            {
                Assert.Equal(brands[i].Name, result[i].Name);
            }
        }
    }
}
