using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress()
                .WithName("Mail Adresi");
            RuleFor(x => x.Password)
                .NotNull()
                .WithName("Parola");
        }
    }
}
