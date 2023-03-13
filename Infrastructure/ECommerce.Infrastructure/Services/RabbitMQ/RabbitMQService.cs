using ECommerce.Application.Features.Auth.Dtos;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ECommerce.Infrastructure.Services.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendMailQueue(User user)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://dbhwosdy:kaPv9awYo7O_SsHHj01L2QInn8zbm4GZ@woodpecker.rmq.cloudamqp.com/dbhwosdy")
            };

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("MailQueue", exclusive: false);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));
            channel.BasicPublish(string.Empty, "MailQueue", null, body);


        }
    }
}
