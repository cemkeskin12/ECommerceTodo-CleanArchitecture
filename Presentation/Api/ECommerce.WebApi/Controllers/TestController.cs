using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using ECommerce.ElasticSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;

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
                orderBy: x => x.OrderByDescending(x => x.Name),
                include: x => x.Include(x => x.Brand).Include(x => x.Subcategory),
                currentPage: 1, pageSize: 1);
            return Ok(result);
        }
        [HttpGet("Test3")]
        public async Task<IActionResult> Test3(string query)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).BasicAuthentication("elastic", "wRRlotcitNxzYNCEiA7q").DefaultIndex("a").CertificateFingerprint("94:75:CE:4F:EB:05:32:83:40:B8:18:BB:79:01:7B:E0:F0:B6:C3:01:57:DB:4D:F5:D8:B8:A6:BA:BD:6D:C5:C4");

            var client = new ElasticClient(settings);



            var searchResponse = await client.SearchAsync<Brand>(s => s
           .From(0)
           .Size(10)
           .Query(q => q
               .Match(m => m
                   .Field(f => f.Name)
                   .Query(query))));

            return Ok(searchResponse.Documents);
        }
        [HttpPost]
        public async Task<IActionResult> AddIndex()
        {
            var brands = new List<Brand>() { new Brand("monste", "piçture.png"), new Brand("kamaste", "asd.png") };

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).BasicAuthentication("elastic", "wRRlotcitNxzYNCEiA7q").DefaultIndex("a").CertificateFingerprint("94:75:CE:4F:EB:05:32:83:40:B8:18:BB:79:01:7B:E0:F0:B6:C3:01:57:DB:4D:F5:D8:B8:A6:BA:BD:6D:C5:C4");

            var client = new ElasticClient(settings);

            var indexResponse = await client.IndexManyAsync(brands);
            return Ok(indexResponse);
        }
    }
}
