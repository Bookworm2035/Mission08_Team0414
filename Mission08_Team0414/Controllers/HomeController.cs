using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _TaskContext;

        public HomeController(ITaskRepository temp)
        {
            _TaskContext = temp;
        }
  

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            ViewBag.Category = _TaskContext.Category
               .OrderBy(x => x.CategoryName)
               .ToList();
            return base.View("Tasks", new SubmittedTask());
        }

        [HttpPost]
        public IActionResult Tasks(SubmittedTask response)
        {
            if (ModelState.IsValid)
            {
                //confirm that the submission meets requirements
                ViewBag.Category = _TaskContext.Category
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                _TaskContext.AddSubmittedTask(response);

                return View("Confirmation", response);

            }
            else
            {
                //if bad return error meessages
                ViewBag.Category = _TaskContext.Category
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }

        [HttpGet]
        //View that displays all the quadrants with tasks?
        public IActionResult Quadrants()
        {
            //display database
            var SubmittedTasks = _TaskContext.SubmittedTasks/*.Include(c =>c.Category)*/
                         .Where(x => x.IsCompleted == false)
                         .OrderBy(x => x.TaskId).ToList();
            return View();
        }
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

    //        ViewBag.Categories = _TaskContext.Categories
    //            .OrderBy(x => x.CategoryName)
    //            .ToList();
    //        return View("Tasks", recordToEdit);
    //    }
    //    [HttpPost]
    //    public IActionResult Edit(Task updateresponse)
    //    {
    //        //update the datebase with the new edits
    //        _TaskContext.Update(updateresponse);
    //        _TaskContext.SaveChanges();
    //        //return to view
    //        return RedirectToAction("Quadrant", "Home");
    //    }
    //    public IActionResult Add()
    //    {
    //        return View("Tasks");
    //    }
