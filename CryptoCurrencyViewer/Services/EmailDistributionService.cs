using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.MainPagesModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CryptoCurrencyViewer.Services;

    public class EmailDistributionService : IEmailDistributionService
    {

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Daniil", "skorikdaniil17@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;

        emailMessage.Body = new TextPart("plain") { Text = message };

        using (var client = new SmtpClient())
        {
            // Подключение к SMTP-серверу Gmail
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            // Аутентификация с использованием вашего адреса и пароля Gmail
            await client.AuthenticateAsync("ccrot26@gmail.com", "Daniil2006");
            // Отправка сообщения
            await client.SendAsync(emailMessage);
            // Отключение от сервера
            await client.DisconnectAsync(true);
        }
    }


}

