using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _TaskContext;
        ////This is whatever the database is named?
        //private ITaskRepository _repo;

        //public HomeController(ITaskRepository temp)
        //{
        //    _repo = temp;
        //}

        public HomeController(TaskContext TaskContext)
        {
            _TaskContext = TaskContext;
        }
  

        public IActionResult Index()
        {
            return View();
        }

        ////View that displays allows you to add tasks?
        //[HttpGet]
        //public IActionResult Tasks()
        //{
        //    ViewBag.Categories = _TaskContext.Categories
        //       .OrderBy(x => x.CategoryName)
        //       .ToList();
        //    return base.View("Tasks", new System.Threading.Tasks.Task());
        //}

        //[HttpPost]
        //public IActionResult Tasks(System.Threading.Tasks.Task response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //confirm that the submission meets requirements
        //        _TaskContext.Movies.Add(response);
        //        _TaskContext.SaveChanges();
        //        return View("Confirmation", response);

        //    }
        //    else
        //    {
        //        //if bad return error meessages
        //        ViewBag.Categories = _TaskContext.Categories
        //            .OrderBy(x => x.CategoryName)
        //            .ToList();
        //        return View(response);
        //    }
        //}
        ////View that displays all the quadrants with tasks?
        //public IActionResult Quadrants()
        //{
        //    //display database
        //    var tasks = _TaskContext.Tasks.Include(m => m.Category)
        //                 //.Where(x => x.COLUM == value)
        //                 .OrderBy(x => x.TaskId).ToList();
        //    return View(tasks);
        //}
        ////delete a task
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    //delete the record by ID num
        //    var recordToDelete = _TaskContext.Tasks
        //        .Single(x => x.TaskId == id);

        //    return View(recordToDelete);
        //}
        //[HttpPost]
        //public IActionResult Delete(System.Threading.Tasks.Task task)
        //{
        //    //actually delete it
        //    _TaskContext.Movies.Remove(task);
        //    _TaskContext.SaveChanges();

        //    return RedirectToAction("Quadrant");
        //}
        ////edit a task
        //[HttpGet]
        //public IActionResult Edit(int id)

        //{
        //    var recordToEdit = _TaskContext.Task
        //        .Single(x => x.TaskId == id);
          

        //    ViewBag.Categories = _TaskContext.Categories
        //        .OrderBy(x => x.CategoryName)
        //        .ToList();
        //    return View("Tasks", recordToEdit);
        //}
        //[HttpPost]
        //public IActionResult Edit(System.Threading.Tasks.Task updateresponse)
        //{
        //    //update the datebase with the new edits
        //    _TaskContext.Update(updateresponse);
        //    _TaskContext.SaveChanges();
        //    //return to view
        //    return RedirectToAction("Quadrant", "Home");
        //}
        //public IActionResult Add()
        //{
        //    return View("Tasks");
        //}

    }
}
