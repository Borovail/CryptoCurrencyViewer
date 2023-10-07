using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoCurrencyViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CryptoModel> cryptos = new List<CryptoModel>()
 {
      new CryptoModel { Name = "Ethereum", Abbreviation="BTC", Price = 27561 , ImageUrl = "https://s2.coinmarketcap.com/static/img/coins/64x64/1.png" },
         new CryptoModel { Name = " Bitcoin ", Abbreviation="BTC", Price = 1633, ImageUrl ="https://s2.coinmarketcap.com/static/img/coins/64x64/1027.png" },
 new CryptoModel { Name = "XRP", Abbreviation = "XRP", Price = 0.522, ImageUrl ="https://s2.coinmarketcap.com/static/img/coins/64x64/3408.png" },
 new CryptoModel { Name = "Tether ", Abbreviation = "USDt", Price = 1, ImageUrl="https://s2.coinmarketcap.com/static/img/coins/64x64/825.png" },
  new CryptoModel { Name = "BNB", Abbreviation = "BNB", Price = 212, ImageUrl ="https://s2.coinmarketcap.com/static/img/coins/64x64/1839.png" },
  new CryptoModel { Name = "Solana ", Abbreviation = "SOL", Price = 23, ImageUrl ="https://s2.coinmarketcap.com/static/img/coins/64x64/5426.png" },
   new CryptoModel     {        Name = "Tron",    Abbreviation = "TRX",     Price = 0.0089,    ImageUrl="https://s2.coinmarketcap.com/static/img/coins/64x64/1958.png" }
 };



            return View(cryptos);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}