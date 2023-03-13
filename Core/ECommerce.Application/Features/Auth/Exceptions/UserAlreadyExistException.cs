using ECommerce.Resource;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseAuthException
    {
        public UserAlreadyExistException() : base(nameof(ExceptionResource.UserAlreadyExist))
        {
        }
    }
}
