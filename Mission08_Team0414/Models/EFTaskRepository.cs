
using SQLitePCL;

namespace Mission08_Team0414.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Category => _context.Category.ToList();
        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}
