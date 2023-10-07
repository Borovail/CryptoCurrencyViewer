using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace CryptoCurrencyViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICryptoService _cryptoService;
        public HomeController(ILogger<HomeController> logger, ICryptoService cryptoService)
        {
            _logger = logger;
            _cryptoService = cryptoService;

        }

        public async Task<IActionResult> Index()
        {
            var BTC = await _cryptoService.AddCryptoAsync("bitcoin");
            return View(BTC);

        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult AddCrypto(string cryptoName)
        {
           
            return RedirectToAction("Index");  
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}