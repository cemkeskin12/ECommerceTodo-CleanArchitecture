using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest>
    {
        private readonly IAuthService authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authService.Register(request);
            return await Task.FromResult(Unit.Value);
        }
    }
}
