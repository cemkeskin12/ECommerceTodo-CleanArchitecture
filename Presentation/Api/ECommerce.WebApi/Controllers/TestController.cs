using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("Test1")]
        public async Task<IActionResult> Test1()
        {
            await unitOfWork.GetRepository<Product>().TestAsync();
            return Ok();
        }
        [HttpGet("Test2")]
        public async Task<IActionResult> Test2()
        {
            var result = await unitOfWork.GetRepository<Product>().GetAllByPagingAsync(predicate: x => !x.IsDeleted,
                orderBy: x=>x.OrderByDescending(x=>x.Name),
                include: x => x.Include(x => x.Brand).Include(x => x.Subcategory),
                currentPage: 1,pageSize:1);
            return Ok(result);
        }
    }
}
