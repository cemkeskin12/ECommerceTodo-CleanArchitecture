using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Commands.EmailConfirmation
{
    public class EmailConfirmationCommandValidator : AbstractValidator<EmailConfirmationCommandRequest>
    {
        public EmailConfirmationCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotNull();
            RuleFor(x => x.Token).NotNull();
        }
    }
}
