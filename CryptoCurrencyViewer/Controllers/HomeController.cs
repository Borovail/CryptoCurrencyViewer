using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.MainPagesModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CryptoCurrencyViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _cryptoService;
        public HomeController(ILogger<HomeController> logger, IApiService cryptoService)
        {
            _logger = logger;
            _cryptoService = cryptoService;

        }

        public async Task<IActionResult> Index()
        {

            return View(new List<CryptoModel> { await _cryptoService.GetCryptoInfoByName("bitcoin")}) ;
        }

        [HttpPost]
        public JsonResult UpdateOrDeleteSelectedCrypto([FromBody] UpdateCryptoRequest request)
        {
            bool success = false;
            string action = request.action;
            string selectedCrypto = request.selectedCrypto;
            CryptoModel model = new CryptoModel();

            if(action == TagManager.DELETE_ACTION)
            {

                ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto).remove   bd.uptade();

                success = true;
            }
            if(action == TagManager.UPDATE_ACTION)
            {

                ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto) =   ApiServices.GetCryptoInfoByName(selectedcrypto)  bd.uptade();
                success = true;
            }

            return Json(new { success = success, action = action });
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