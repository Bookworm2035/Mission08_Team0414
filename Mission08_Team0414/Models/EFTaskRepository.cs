
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

        public List<SubmittedTask> SubmittedTasks => _context.SubmittedTasks.ToList();
        public List<Category> Category => _context.Category.ToList();

        //List<SubmittedTask> ITaskRepository.SubmittedTasks => throw new NotImplementedException();

        public void AddSubmittedTask(SubmittedTask task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        //public void AddTask(SubmittedTask task)
        //{
        //    _context.Add(task);
        //    _context.SaveChanges();
        //}

    }
}
