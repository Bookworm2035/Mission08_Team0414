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

        //View that displays allows you to add tasks?
        public IActionResult Tasks()
        {
            return View();
        }

        //View that displays all the quadrants with tasks?
        public IActionResult Quadrants()
        {
            return View();
        }
        //delete a task
        public IActionResult Delete()
        {
            return View();
        }
        //edit a task
        public IActionResult Edit()
        {
            return View();
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}
    }
}
