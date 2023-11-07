namespace CryptoCurrencyViewer.Interfaces;

public interface IEmailDistributionService
{
    Task SendEmailAsync(string email, string subject, string message);
}
