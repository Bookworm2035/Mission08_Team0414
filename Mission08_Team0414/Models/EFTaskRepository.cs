
using SQLitePCL;

namespace Mission08_Team0414.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private SubmittedTaskContext _context;
        public EFTaskRepository(SubmittedTaskContext temp)
        {
            _context = temp;
        }

        // Defining properties
        public List<SubmittedTask> SubmittedTasks => _context.SubmittedTasks.ToList();
        public List<Category> Category => _context.Category.ToList();

        
        // Repository methods
        public void AddSubmittedTask(SubmittedTask task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void DeleteSubmittedTask(SubmittedTask task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }

        public void EditSubmittedTask(SubmittedTask task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

       
        //public void AddTask(SubmittedTask task)
        //{
        //    _context.Add(task);
        //    _context.SaveChanges();
        //}

    }
}
