using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Context;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Moq.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Test.Repositories
{
    public class RepositoryTests
    {
        [Fact]
        public async Task GetAsync_ReturnsItem_WhenFoundInDatabase()
        {
            // Arrange
            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseInMemoryDatabase(databaseName: "test_database")
            //    .Options;

            //var dbContext = new AppDbContext(options);

            //var mockDbContext = new Mock<AppDbContext>();
            

            //await mockDbContext.Object.AddAsync(new TestEntity(1, "Asda"));
            //await mockDbContext.Object.AddAsync(new TestEntity(2, "casta"));
            //await mockDbContext.Object.SaveChangesAsync();


            List<Brand> brands = new()
            {
                new Brand("cem","as"),
                new Brand("bem","bs")
            };

            List<TestEntity> testEntity = new();
            var employeeContextMock = new Mock<AppDbContext>();
            employeeContextMock.Setup<DbSet<Brand>>(x => x.Brands)
                .ReturnsDbSet(brands);




            var repository = new Mock<IRepository<TestEntity>>();

            var returns = repository.Setup(x => x.GetAllByPagingAsync(It.IsAny<Expression<Func<TestEntity, bool>>>(),
                It.IsAny<Func<IQueryable<TestEntity>, IOrderedQueryable<TestEntity>>>(),
                It.IsAny<Func<IQueryable<TestEntity>, IIncludableQueryable<TestEntity, object>>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<bool>(),
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>())).ReturnsAsync((Expression<Func<TestEntity, bool>> expression, Func<IQueryable<TestEntity>, IOrderedQueryable<TestEntity>> orderBy,
          Func<IQueryable<TestEntity>, IIncludableQueryable<TestEntity, object>> include,int current,int page,bool isAsc, bool enableTracking, CancellationToken cancellationToken) =>
            {
                IList<TestEntity> result = new List<TestEntity>();
                if (expression == null)
                    result = testEntity;
                else
                    result = testEntity.Where(expression.Compile()).ToList();

                return result;
            });



            // Assert
            Assert.NotNull(returns);
        }
    }
    public class TestEntity : IEntityBase
    {
        public TestEntity()
        {

        }
        public TestEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
