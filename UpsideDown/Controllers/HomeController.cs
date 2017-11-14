

using Microsoft.AspNetCore.Mvc;
using UpsideDown.Models;

namespace UpsideDown.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Quote
            {
                Id = 1,
                QuoteText = "Guys!...",
                Sayer = "Dustin"

            };

            return View(model);
        }

        public string Moop()
        {
            // servers this up when you go to http://localhost:5001/home
            return "No thanks, from home controller";
        }
    }
}