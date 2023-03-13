using ECommerce.Resource;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class EmailCouldNotBeConfirmedException : BaseAuthException
    {
        public EmailCouldNotBeConfirmedException() : base(nameof(ExceptionResource.EmailCouldNotBeConfirmed))
        {
        }
    }
}
