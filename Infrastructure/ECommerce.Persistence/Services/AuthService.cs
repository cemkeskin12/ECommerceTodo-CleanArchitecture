using ECommerce.Application.Features.Auth.Commands.EmailConfirmation;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Features.Auth.Dtos;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Mails;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.Tokens;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper mapper;
        private readonly IRabbitMQService rabbitMQService;
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IMailService mailService;
        private readonly SignInManager<User> signInManager;

        public AuthService(IMapper mapper,IRabbitMQService rabbitMQService, AuthRules authRules, UserManager<User> userManager, ITokenService tokenService, IMailService mailService, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.rabbitMQService = rabbitMQService;
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.mailService = mailService;
            this.signInManager = signInManager;
        }
        public async Task Register(RegisterCommandRequest request)
        {
            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;

            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                await SendEmailConfirmation(user);
            }
        }
        private async Task<EmailConfirmationDto> SendEmailConfirmation(User user)
        {

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = CustomEncoders.UrlEncode(token);

            var confirmationUrl = @$"https://localhost:7165/Account/EmailConfirmation/?email={user.Email}&token={encodedToken}";

            try
            {
                await mailService.SendMessageAsync(user.Email, "Mail Aktivasyonu",
                $"""

                    <h4><strong>Sayın {user.FirstName} {user.LastName}; </strong><h4>
                    <br />
                    <p> Mail Adresinizi doğrulamak için <a href="{confirmationUrl}" target="_blank"> buraya </a> tıklayınız.
                    """,
                "CMK - Shop");
            }
            catch (Exception)
            {
                throw;
            }
            return new()
            {
                Email = user.Email,
                Token = encodedToken
            };
        }
        public async Task CheckEmailConfirmation(EmailConfirmationCommandRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            var decodedToken = CustomEncoders.UrlDecode(request.Token);

            var result = await userManager.ConfirmEmailAsync(user, decodedToken);

            await authRules.EmailShouldBeConfirmed(result);

        }

        public async Task<Domain.Entities.Token> Login(LoginCommandRequest request)
        {
            User user = await userManager.FindByEmailAsync(request.Email);

            await authRules.UserEmailShouldBeExists(user);

            var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

            await authRules.UserPasswordShouldBeMatch(result);

            var accessToken = tokenService.CreateAccessToken(user, 7000);
            var token = new Domain.Entities.Token
            {
                AccessToken = accessToken.AccessToken,
                Expiration = accessToken.Expiration
            };
            return token;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}
