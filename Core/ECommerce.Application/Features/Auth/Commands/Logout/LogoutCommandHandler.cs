using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommandRequest>
    {
        private readonly IAuthService authService;

        public LogoutCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<Unit> Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
        {
            await authService.Logout();
            return await Task.FromResult(Unit.Value);
        }
    }
}
