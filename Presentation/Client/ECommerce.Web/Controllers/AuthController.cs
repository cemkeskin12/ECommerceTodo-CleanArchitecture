using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Web.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ECommerce.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly HttpClient httpClient;

        public AuthController(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.httpClient = httpClient;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest command)
        {

            var request = await httpClient.PostAsJsonAsync(AuthEndpoints.Login, command);
            if (request.IsSuccessStatusCode)
            {
                var token = await request.Content.ReadFromJsonAsync<Domain.Entities.Token>();
                httpContextAccessor.HttpContext.Session.SetString("Token", token.AccessToken);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
