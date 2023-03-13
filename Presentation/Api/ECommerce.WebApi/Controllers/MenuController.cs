using ECommerce.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService applicationService;

        public MenuController(IMenuService applicationService)
        {
            this.applicationService = applicationService;
        }
        [HttpGet]
        public IActionResult GetTheLatestMenuEndPoints()
        {
           var datas = applicationService.GetMenuDefinitionEndPoints("");
            return Ok(datas);
        }
    }
}
