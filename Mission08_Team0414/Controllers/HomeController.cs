using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskContext _TaskContext;

        public HomeController(TaskContext TaskContext)
        {
            _TaskContext = TaskContext;
        }

        public IActionResult Index()
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
        public IActionResult Edit(int id)
        {
            var recordToEdit = _TaskContext.Task
                .Single(x => x.TaskId == id);
          

            ViewBag.Categories = _TaskContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Tasks", recordToEdit);
        }

        public IActionResult Add()
        {
            return View("Tasks");
        }
    }
}
