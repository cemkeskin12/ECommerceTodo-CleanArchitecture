using ECommerce.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class InvalidEmailAddressOrPasswordException : BaseAuthException
    {
        public InvalidEmailAddressOrPasswordException() : base(nameof(ExceptionResource.InvalidEmailAddressOrPassword))
        {
        }
    }
}
