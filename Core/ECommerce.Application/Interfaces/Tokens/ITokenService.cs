using ECommerce.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Token CreateAccessToken(User user, int minute);
        Guid? ValidateJwtToken(string token);
    }
}
