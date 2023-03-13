using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.RabbitMQ.Configurations
{
    public class RabbitMQConfiguration : IRabbitMQConfiguration
    {
        public IConfiguration Configuration { get; }
        public RabbitMQConfiguration(IConfiguration configuration) => Configuration = configuration;
        
        public string HostName => Configuration.GetSection(HostName).Value;

        public string UserName => throw new NotImplementedException();

        public string Password => throw new NotImplementedException();
        public string MailFromAddress => Configuration.GetSection("Smtp:FromAddress").Value;
        public string MailUserName => Configuration.GetSection("Smtp:UserName").Value;
        public string MailPassword => Configuration.GetSection("Smtp:Password").Value;
        public string MailHost => Configuration.GetSection("Smtp:Host").Value;


    }
}
