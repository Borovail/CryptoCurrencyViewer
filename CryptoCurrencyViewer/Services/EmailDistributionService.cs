using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.MainPagesModels;

namespace CryptoCurrencyViewer.Services
{
    public class EmailDistributionService : IEmailDistributionService
    {
        private readonly AppDbContext _context;

        public EmailDistributionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Subscribe(string email)
        {
            ///проверять нету ли его уже подписанного

            var subscriber = new SubscriberModel { Email = email, IsSubscribed = true };
            //_context.Subscribers.Add(subscriber);
            //await _context.SaveChangesAsync();
        }

        public async Task Unsubscribe(string email)
        {
            ///проверять подписан ли он

            //var subscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Email == email);
            //if (subscriber != null)
            //{
            //    subscriber.IsSubscribed = false;
            //    _context.Subscribers.Update(subscriber);
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task SendTestEmail()
        {
            
            //var subscribers = await _context.Subscribers.Where(s => s.IsSubscribed).ToListAsync();
            //foreach (var subscriber in subscribers)
            //{
            //}
        }
    }
}
