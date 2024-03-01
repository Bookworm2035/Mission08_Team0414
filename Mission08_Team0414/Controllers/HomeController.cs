using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller

    { //databse
        private ITaskRepository _TaskContext;

        //repository set up with database
        public HomeController(ITaskRepository temp)
        {
            _TaskContext = temp;
        }

        //index view
        public IActionResult Index()
        {
            return View();
        }

        //Task view that is passed the category names and task objects
        public IActionResult Tasks()
        {
            ViewBag.Category = _TaskContext.Category
               .OrderBy(x => x.CategoryName)
               .ToList();
            return base.View("Tasks", new SubmittedTask());
        }

        //post action that shows conformation page and adds response to database
        [HttpPost]
        public IActionResult Tasks(SubmittedTask response)
        {
            if (ModelState.IsValid)
            {
                //confirm that the submission meets requirements
                ViewBag.Category = _TaskContext.Category
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                //repo pattern calls add task method
                _TaskContext.AddSubmittedTask(response);
                return View("Confirmation", response);

            }
            else
            {
                //make them resubmit
                //if bad return error meessages
                ViewBag.Category = _TaskContext.Category
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }

        [HttpGet]
        //View that displays all the quadrants with tasks and it only shows those that are not done
        public IActionResult Quadrants()
        {
            var SubmittedTasks = _TaskContext.SubmittedTasks
                         .Where(x => x.IsCompleted == false)
                         .OrderBy(x => x.TaskId).ToList();
            return View(SubmittedTasks);
        }
        //delete a task, pulls in a specific ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete the record by ID num
            var recordToDelete = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        //calls the repo pattern method to delete
        public IActionResult Delete2(SubmittedTask task)
        {
            var recordToDelete = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == task.TaskId);
            //actually delete it
            _TaskContext.DeleteSubmittedTask(recordToDelete);
            //goes back to quadrant views
            return RedirectToAction("Quadrants", "Home");
        }

        //edit a task, pulls in specific ID
        [HttpGet]
        public IActionResult Edit(int id)

        {
            var recordToEdit = _TaskContext.SubmittedTasks
                .Single(x => x.TaskId == id);

            ViewBag.Category = _TaskContext.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Tasks", recordToEdit);
        }

        //updates the reccord and redirects to view
        [HttpPost]
        public IActionResult Edit(SubmittedTask updateresponse)
        {
            //update the datebase with the new edits
            _TaskContext.EditSubmittedTask(updateresponse);
            //return to view
            return RedirectToAction("Quadrants", "Home");
        }

    }
}
