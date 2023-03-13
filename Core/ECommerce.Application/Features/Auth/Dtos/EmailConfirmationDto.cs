using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Dtos
{
    public class EmailConfirmationDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
