using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }
    }
}
