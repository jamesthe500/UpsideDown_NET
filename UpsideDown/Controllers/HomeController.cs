
using UpsideDown.Services;
using Microsoft.AspNetCore.Mvc;
using UpsideDown.Models;

namespace UpsideDown.Controllers
{
    public class HomeController : Controller
    {
        private IQuoteData _quoteData;

        public HomeController(IQuoteData quoteData)
        {
            _quoteData = quoteData;
        }

        public IActionResult Index()
        {
            var model = _quoteData.SelectRandomQuote();

            return View(model);
        }

     }
}