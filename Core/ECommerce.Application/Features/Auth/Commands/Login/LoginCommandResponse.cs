using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Auth.Commands.Login
{
    public class LoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
