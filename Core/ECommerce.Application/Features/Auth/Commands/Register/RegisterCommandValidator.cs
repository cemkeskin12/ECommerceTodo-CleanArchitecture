using FluentValidation;

namespace ECommerce.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(35)
                .WithName("Adınız");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(35)
                .WithName("Soyadınız");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MinimumLength(2)
                .MaximumLength(35)
                .WithName("Email Adresi");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(35)
                .WithName("Parola");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(35)
                .WithName("Parola Tekrarı");
        }
    }
}
