using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Domain.Entities;
using ECommerce.ElasticSearch;
using ECommerce.ElasticSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IElasticSearch elasticSearch;

        public ElasticSearchController(IElasticSearch elasticSearch)
        {
            this.elasticSearch = elasticSearch;
        }
        /*
         Task<IElasticSearchResult> CreateNewIndexAsync(IndexModel indexModel);
        Task<IElasticSearchResult> InsertAsync(ElasticSearchInsertUpdateModel model);
        Task<IElasticSearchResult> InsertManyAsync(string indexName, object[] items);
        IReadOnlyDictionary<IndexName, IndexState> GetIndexList();

        Task<List<ElasticSearchGetModel<T>>> GetAllSearch<T>(SearchParameters parameters)
            where T : class;

        Task<List<ElasticSearchGetModel<T>>> GetSearchByField<T>(SearchByFieldParameters fieldParameters)
            where T : class;

        Task<List<ElasticSearchGetModel<T>>> GetSearchBySimpleQueryString<T>(SearchByQueryParameters queryParameters)
            where T : class;

        Task<IElasticSearchResult> UpdateByElasticIdAsync(ElasticSearchInsertUpdateModel model);
        Task<IElasticSearchResult> DeleteByElasticIdAsync(ElasticSearchModel model);
         */

        [HttpPost]
        public async Task<IActionResult> CreateNewIndex(IndexModel index)
        {
            IElasticSearchResult result = await elasticSearch.CreateNewIndexAsync(index);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ElasticSearchInsertUpdateModel insertModel)
        {
            IElasticSearchResult result = await elasticSearch.InsertAsync(insertModel);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertMany(string indexName, object[] items)
        {
            IElasticSearchResult result = await elasticSearch.InsertManyAsync(indexName, items);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetIndexList()
        {
            var result = elasticSearch.GetIndexList();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSearch([FromQuery] SearchParameters parameters)
        {
            var result = await elasticSearch.GetAllSearch<Brand>(parameters);
            return Ok(result);
        }


    }
}
