using ECommerce.Application.Features.Auth.Exceptions;
using ECommerce.Application.Rules;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task EmailShouldBeConfirmed(IdentityResult result)
        {
            if (!result.Succeeded) throw new EmailCouldNotBeConfirmedException();
            return Task.CompletedTask;
        }
        public Task UserEmailShouldBeExists(User? user)
        {
            if (user is null) throw new InvalidEmailAddressOrPasswordException();
            return Task.CompletedTask;
        }
        public Task UserPasswordShouldBeMatch(SignInResult result)
        {
            if (!result.Succeeded) throw new InvalidEmailAddressOrPasswordException();
            return Task.CompletedTask;
        }
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;

        }
    }
}
