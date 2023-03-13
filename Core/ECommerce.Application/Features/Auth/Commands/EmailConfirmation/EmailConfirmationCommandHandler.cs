using ECommerce.Application.Interfaces.Services;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.EmailConfirmation
{
    public class EmailConfirmationCommandHandler : IRequestHandler<EmailConfirmationCommandRequest>
    {
        private readonly IAuthService authService;

        public EmailConfirmationCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<Unit> Handle(EmailConfirmationCommandRequest request, CancellationToken cancellationToken)
        {
            await authService.CheckEmailConfirmation(request);
            return await Task.FromResult(Unit.Value);
        }
    }
}
