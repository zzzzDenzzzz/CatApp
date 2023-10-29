using CatApp.Models;
using CatApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatApiService catApiService;

        public HomeController(CatApiService catApiService)
        {
            this.catApiService = catApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string breed)
        {
            var result = await catApiService.SearchByBreedAsync(breed);

            ViewBag.Result = result;
            ViewBag.searchBreed = breed;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}