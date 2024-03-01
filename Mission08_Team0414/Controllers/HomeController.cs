using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            var SubmittedTasks = _TaskContext.SubmittedTasks
                         .Where(x => x.IsCompleted == false)
                         .OrderBy(x => x.TaskId).ToList();
            return View(SubmittedTasks);
        }
        //delete a task
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete the record by ID num
            var recordToDelete = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete2(SubmittedTask task)
        {
            var recordToDelete = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == task.TaskId);
            //actually delete it
            _TaskContext.DeleteSubmittedTask(recordToDelete);

            return RedirectToAction("Quadrant", "Home");
        }


        //edit a task
        [HttpGet]
        public IActionResult Edit(int id)

        {
            var recordToEdit = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == id);


            ViewBag.Categories = _TaskContext.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Tasks", recordToEdit);
        }

        public IActionResult Edit(SubmittedTask updateresponse)
        {
            //update the datebase with the new edits
            _TaskContext.EditSubmittedTask(updateresponse);
            //return to view
            return RedirectToAction("Quadrant", "Home");
        }
    }

}

        
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
//    
//    public IActionResult Add()
//    {
//        return View("Tasks");
//    }
