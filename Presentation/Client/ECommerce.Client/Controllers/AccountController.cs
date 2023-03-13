using ECommerce.Application.DTOs.Account;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Features.Auth.Queries.Logout;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Mails;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Identity;
using ECommerce.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ECommerce.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly IAuthService accountService;
        private readonly IToastNotification toastNotification;
        private readonly IMapper mapper;
        private readonly IMailService mailService;
        private readonly UserManager<User> userManager;

        public AccountController(IMediator mediator,IAuthService accountService, IToastNotification toastNotification, IMapper mapper, IMailService mailService, UserManager<User> userManager)
        {
            this.mediator = mediator;
            this.accountService = accountService;
            this.toastNotification = toastNotification;
            this.mapper = mapper;
            this.mailService = mailService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand registerCommandRequest)
        {
            if(ModelState.IsValid)
            {
                var result = await mediator.Send(registerCommandRequest);

                if (result.IdentityResult.Succeeded)
                    return RedirectToAction(nameof(SuccessRegistration));
                else
                    result.IdentityResult.AddToModelErrorIdentity(ModelState);
            }
            return View();

        }
        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        //[HttpGet("Auth/EmailConfirmation/{email:string}/{token:string}")]
        [HttpGet]
        public async Task<IActionResult> EmailConfirmation(EmailConfirmationDto emailConfirmationDto)
        {
            var result = await accountService.CheckEmailConfirmation(emailConfirmationDto);
            return View(result.Succeeded ? nameof(EmailConfirmation) : "Error");

        }
        //https://localhost:7165/Auth/EmailConfirmation/?email=cemkeskin12@gmail.com&token=Q2ZESjhJcHYxWTRGbXo1UGx5ZU1oSXZqNVFkS3RkVFpTZzZZQmdrOWFxUTB1V05HQ1pFMStCZjM4VzVjNW5MK09oSHp6S0FsZVpJZTVVRUV0RkFVY2xyQ2dXRmVnNGtObmhiRGw4akRXMThvbkp5YW4xeGZxMTZQZ0VMREtUSUo3eitjdVVKOHd4MS92S1FLTUN4WUg0N0F1Mndad0Z2MUpZTjhRZCtuZ2dIUWl2NVJrbEwvbFVuWkRUektQT3NNZVdzQTNMaTdIbzhSbVpwbTBkTE82WWxCUWxnMVhleFNQS3RsTTVjM0cwZlZSekRVNVQ4YVByRlEySW45Wmx5Ti9GeE9mUT09

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommandRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(loginCommandRequest);
                if (result != null)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("", "Giriş yapabilmek için email adresinizi onaylamanız gerekmektedir!");
                }
            }
            return View();

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await mediator.Send(new LogoutQueryRequest());
            return RedirectToAction("Index", "Home");
        }
    }
}
