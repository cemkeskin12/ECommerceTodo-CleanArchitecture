//using ECommerce.Application.Features.Orders.Commands.CreateOrder;
//using ECommerce.Application.Features.Orders.Commands.Dtos;
//using ECommerce.Application.Interfaces.AutoMappers;
//using ECommerce.Application.Interfaces.UnitOfWorks;
//using ECommerce.Domain.Entities;
//using ECommerce.Persistence.Services;
//using Microsoft.AspNetCore.Http;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECommerce.Persistence.Test.Services
//{
//    public class OrderServiceTests
//    {
//        private readonly Mock<IUnitOfWork> mockUnitOfWork;
//        private readonly Mock<IMapper> mockMapper;
//        private readonly Mock<IHttpContextAccessor> mockHttpContextAccessor;
//        private readonly OrderService orderService;

//        public OrderServiceTests()
//        {
//            mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockMapper = new Mock<IMapper>();
//            mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
//            orderService = new OrderService(mockUnitOfWork.Object, mockMapper.Object, mockHttpContextAccessor.Object);
//        }

//        [Fact]
//        public async Task CreateOrder_Should_Create_Order()
//        {
//            // Arrange
//            var orderCommand = new CreateOrderCommandRequest
//            {
//                CreateOrderDtos = new List<CreateOrderDto>
//            {
//                new CreateOrderDto
//                {
//                    ProductId = 1,
//                    ProductCount = 2
//                },
//                new CreateOrderDto
//                {
//                    ProductId = 2,
//                    ProductCount = 1
//                }
//            }
//            };

//            var userId = Guid.NewGuid().ToString();
//            mockHttpContextAccessor.Setup(x => x.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Returns(userId);

//            var product1 = new Product { Id = 1, Price = 10 };
//            var product2 = new Product { Id = 2, Price = 20 };
//            mockUnitOfWork.Setup(x => x.GetRepository<Product>().GetAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync((Expression<Func<Product, bool>> filter) =>
//            {
//                if (filter.Compile().Invoke(product1))
//                {
//                    return product1;
//                }
//                else if (filter.Compile().Invoke(product2))
//                {
//                    return product2;
//                }
//                else
//                {
//                    return null;
//                }
//            }));

//            mockUnitOfWork.Setup(x => x.GetRepository<Order>().AddAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
//            mockUnitOfWork.Setup(x => x.GetRepository<OrderProduct>().AddAsync(It.IsAny<OrderProduct>())).Returns(Task.CompletedTask);
//            mockUnitOfWork.Setup(x => x.SaveAsync()).Returns(await Task.CompletedTask);

//            // Act
//            await orderService.CreateOrder(orderCommand);

//            // Assert
//            mockHttpContextAccessor.Verify(x => x.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), Times.Once);
//            mockUnitOfWork.Verify(x => x.GetRepository<Product>().GetAsync(It.IsAny<Expression<Func<Product, bool>>>()), Times.Exactly(2));
//            mockUnitOfWork.Verify(x => x.GetRepository<Order>().AddAsync(It.IsAny<Order>()), Times.Once);
//            mockUnitOfWork.Verify(x => x.GetRepository<OrderProduct>().AddAsync(It.IsAny<OrderProduct>()), Times.Exactly(2));
//            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
//        }
//    }
//}
