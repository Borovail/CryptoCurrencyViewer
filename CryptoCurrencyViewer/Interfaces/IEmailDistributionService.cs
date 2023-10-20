namespace CryptoCurrencyViewer.Interfaces
{
    public interface IEmailDistributionService
    {
        Task Subscribe(string email);
        Task Unsubscribe(string email);
        Task SendTestEmail();
    }
}
