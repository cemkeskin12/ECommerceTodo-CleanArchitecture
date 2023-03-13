using ECommerce.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Commands.EmailConfirmation
{
    public class EmailConfirmationCommandRequest : IRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
