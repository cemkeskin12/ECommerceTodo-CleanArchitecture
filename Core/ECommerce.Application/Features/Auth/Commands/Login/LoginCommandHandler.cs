using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService authService;

        public LoginCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await authService.Login(request);

            return new()
            {
                Token = token
            };
        }
    }
}
