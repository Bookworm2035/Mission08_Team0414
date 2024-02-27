using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            return View();
        }
        public IActionResult Quadrants()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
