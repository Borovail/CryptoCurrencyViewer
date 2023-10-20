using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.MainPagesModels;
using CryptoCurrencyViewer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CryptoCurrencyViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;
        private readonly IEmailDistributionService _emailDistributionService;
        private readonly IDbService _dbService;
        public HomeController(ILogger<HomeController> logger,IEmailDistributionService emailDistributionService, IDbService dbService, IApiService apiService)
        {
            _logger = logger;
            _emailDistributionService = emailDistributionService;
            _dbService = dbService;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(new List<CryptoModel> { await _apiService.GetCryptoInfoByNameAsync("bitcoin")}) ;
        }



        ///нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
        [HttpPost]
        public async Task<JsonResult> UpdateSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
            ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto) =   ApiServices.GetCryptoInfoByName(selectedcrypto)  bd.uptade();
            ///
            ////возможно стоит переписать метод  ,  так как он  возвращзет избыточные данные, некоторые данные о критповалюте не могут обновлятся
            var updatedCrypto = await _apiService.GetCryptoInfoByNameAsync(selectedCrypto.selectedCrypto);

            await _dbService.UpdateItemAsync(updatedCrypto);

            return Json(new { success = success, updatedCrypto = updatedCrypto });
        }

        ///нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
        [HttpPost]
        public async Task<JsonResult> DeleteSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
            ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto).remove   bd.uptade();
            ///

            return Json(new { success = success });
        }


        [HttpPost]
        public JsonResult ManageSubscription([FromBody] SubscriberModel user, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "subscribe")
                    _emailDistributionService.Subscribe(user.Email);
                else if (action == "unsubscribe")
                    _emailDistributionService.Unsubscribe(user.Email);
            }

            return Json(new { success = false });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}