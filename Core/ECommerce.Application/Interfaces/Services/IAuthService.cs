using ECommerce.Application.Features.Auth.Commands.EmailConfirmation;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IAuthService
    {
        //Task<(IdentityResult,string)> Register(RegisterDto registerDto);
        Task<Domain.Entities.Token> Login(LoginCommandRequest request);
        Task Logout();
        Task Register(RegisterCommandRequest request);
        Task CheckEmailConfirmation(EmailConfirmationCommandRequest request);
    }
}
