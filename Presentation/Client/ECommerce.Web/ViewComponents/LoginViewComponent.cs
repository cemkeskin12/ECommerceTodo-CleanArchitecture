using ECommerce.Application.DTOs.Account;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using ECommerce.Domain.Entities;
using ECommerce.Web.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ECommerce.Web.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginViewComponent(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
