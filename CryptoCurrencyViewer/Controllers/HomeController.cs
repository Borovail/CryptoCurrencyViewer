using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.MainPagesModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace CryptoCurrencyViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;
        private AppDbContext _appDbContext;
        public HomeController(ILogger<HomeController> logger, IApiService cryptoService, AppDbContext appDbContext)
        {
            _logger = logger;
            _apiService = cryptoService;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {

            return View(new List<CryptoModel> { await _apiService.GetCryptoInfoByNameAsync("bitcoin")}) ;
        }


        [HttpPost]
        public async Task<JsonResult> UpdateSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
            ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto) =   ApiServices.GetCryptoInfoByName(selectedcrypto)  bd.uptade();
            ///
            ////возможно стоит переписать метод  ,  так как он  возвращзет избыточные данные, некоторые данные о критповалюте не могут обновлятся
            var updatedCrypto = await _apiService.GetCryptoInfoByNameAsync(selectedCrypto.selectedCrypto);

            var currentCrypto = await _appDbContext.CryptoList.FirstOrDefaultAsync(c => c.Name == selectedCrypto.selectedCrypto);
            if (currentCrypto != null)
            {
                currentCrypto = updatedCrypto;

                success = true;

                await _appDbContext.SaveChangesAsync();
            }

            return Json(new { success = success, updatedCrypto = updatedCrypto });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
            ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto).remove   bd.uptade();
            ///
            var currentCrypto = await _appDbContext.CryptoList.FirstOrDefaultAsync(c => c.Name == selectedCrypto.selectedCrypto);

            if (currentCrypto != null)
            {
                _appDbContext.CryptoList.Remove(currentCrypto);

                success = true;

                await _appDbContext.SaveChangesAsync();

            }


            return Json(new { success = success });
        }



            [HttpPost]
        public JsonResult ManageSubscription([FromBody] SubscriptionModel model, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == TagManager.SUBSCRIBE_ACTION)
                {
                    // Subscription logic, e.g., save email and name to the database
                }
                else if (action == TagManager.UNSUBSCRIBE_ACTION)
                {
                    // Unsubscription logic, e.g., remove email from the database
                }
                return Json(new { success = true });
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