using ECommerce.Domain.Exceptions;
using ECommerce.Resource;
using System.Globalization;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class BaseAuthException : DomainException
    {
        protected readonly CultureInfo culture;
        protected readonly string nameOfResource;
        private readonly string message;
        public BaseAuthException(string nameOfResource)
        {
            this.nameOfResource = nameOfResource;
            culture = Thread.CurrentThread.CurrentCulture;
            message = ExceptionResource.ResourceManager.GetString(nameOfResource, culture);
        }
        public override string Message => message;
    }
}
