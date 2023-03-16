using ECommerce.Application.Helpers;
using ECommerce.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;
using System.Text;
using Newtonsoft.Json;

internal class Program
{


    static void Main(string[] args)
    {

        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqps://dbhwosdy:as@woodpecker.rmq.cloudamqp.com/dbhwosdy")
        };


        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();
        channel.QueueDeclare("MailQueue", exclusive: false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume("MailQueue", true, consumer);

        consumer.Received += async (sender, e) =>
        {
            var queueUser = JsonConvert.DeserializeObject<User>(Encoding.UTF8.GetString(e.Body.Span));

            Console.WriteLine(queueUser);
            MailSenderQueue(queueUser);

        };
        Console.ReadLine();

    }
    private static void MailSenderQueue(User user)
    {
        var token = $"{Guid.NewGuid}{Guid.NewGuid}";
        var encodedToken = CustomEncoders.UrlEncode(token);

        var confirmationUrl = @$"https://localhost:7165/Account/EmailConfirmation/?email={user.Email}&token={encodedToken}";

        SendMessage(user.Email, "Mail Aktivasyonu",
                    $"""

                    <h4><strong>Sayın {user.FirstName} {user.LastName}; </strong><h4>
                    <br />
                    <p> Mail Adresinizi doğrulamak için <a href="{confirmationUrl}" target="_blank"> buraya </a> tıklayınız.
                    """,
                    "CMK - Shop");
    }
    private static void SendMessage(string to, string subject, string body, string displayName, bool isBodyHtml = true)
    {
        SendMessage(new[] { to }, subject, body, displayName, isBodyHtml);
    }
    private static void SendMessage(string[] tos, string subject, string body, string displayName, bool isBodyHtml = true)
    {
        MailMessage mail = new();
        mail.IsBodyHtml = isBodyHtml;
        foreach (var to in tos)
            mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.From = new("cemkeskin12@gmail.com", displayName);

        SmtpClient smtp = new();
        smtp.Credentials = new NetworkCredential("apikey", "SG.as.as");
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.Host = "smtp.sendgrid.net";
        smtp.SendMailAsync(mail);
    }
}



/*
 TEST 2
 */


