using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.RabbitMQ.Configurations
{
    public interface IRabbitMQConfiguration
    {
        string HostName { get; }
        string UserName { get; }
        string Password { get; }

        string MailFromAddress { get; }
        string MailUserName { get; }
        string MailPassword { get; }
        string MailHost { get; }
    }
}
