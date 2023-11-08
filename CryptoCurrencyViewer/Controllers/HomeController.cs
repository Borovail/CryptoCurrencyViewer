using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Models.MainPagesModels;
using System.Security.Claims;

namespace CryptoCurrencyViewer.Controllers;

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
       // var defaultcryptoList = (await _dbService.GetAllItemsAsync<CryptoModel>())
       //.Where(c => /*c.DefaultCryptoModel.IsFavorite &&*/ c.DefaultCryptoModel.UserId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) // Замените userId на фактический ID пользователя
       //.Select(c => c.DefaultCryptoModel) // Выбираем связанную DefaultCryptoModel напрямую
       //.ToList();

        return View(/*defaultcryptoList*/ new List<DefaultCryptoModel> { new DefaultCryptoModel("D",0.0,"D",0.0)});

    }


  

    /// нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
    /// </summary>
    /// <param name="selectedCrypto"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public async Task<JsonResult> UpdateSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
        ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto) =   ApiServices.GetCryptoInfoByName(selectedcrypto)  bd.uptade();
        ///
        ////возможно стоит переписать метод  ,  так как он  возвращзет избыточные данные, некоторые данные о критповалюте не могут обновлятся
        //var updatedCrypto = await _apiService.GetDefaultCryptoInfoByNameAsync(selectedCrypto.selectedCrypto) ;

        //await _dbService.UpdateItemAsync(updatedCrypto);


        /////delete

        var updatedCrypto = (await _dbService.GetItemByNameAsync<CryptoModel>("bitcoin"));

        updatedCrypto.DefaultCryptoModel.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);


            return Json(new { success = true, updatedCrypto = updatedCrypto });
        }

    ///нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
    [Authorize]
    [HttpPost]
        public async Task<JsonResult> DeleteSelectedCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            bool success = false;
            ////нужно обновить список/ базу данных    типа так  dbcontext.db.first(i=>i.symbol == selectedcrypto).remove   bd.uptade();
            ///

            return Json(new { success = true });
        }

        //[Authorize]
        //[HttpPost]
        //public JsonResult ManageSubscription([FromBody] SubscriberModel user, string action)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (action == "subscribe")
        //            _emailDistributionService.Subscribe(user.Email);
        //        else if (action == "unsubscribe")
        //            _emailDistributionService.Unsubscribe(user.Email);
        //    }

        //    return Json(new { success = false });
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
