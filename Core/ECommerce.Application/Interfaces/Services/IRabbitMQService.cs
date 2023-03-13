using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Features.Auth.Dtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IRabbitMQService
    {
        void SendMailQueue(User user);
    }
}
