using ECommerce.Application.DTOs.Account;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Identity;
using ECommerce.Web.Models;
using ECommerce.Web.Routes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var products = await httpClient.GetFromJsonAsync<IList<GetAllProductsQueryResponse>>(ProductEndpoints.GetAllProducts);
            
            return View(products);
        }
    }
}