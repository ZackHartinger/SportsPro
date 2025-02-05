using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private SportsProContext context { get; set; }
		public HomeController(SportsProContext ctx) => context = ctx;


        [HttpGet()]
        [Route("/")]
        public IActionResult Index()
        {
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/[action]")]
        public IActionResult About()
        {
            return View();
        }
        [NonAction]
        public string GetSlug(string slug) => slug.Replace(' ', '-').ToLower();


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
