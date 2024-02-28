namespace Mission08_Team0414.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        //update this with the database file name
        private PUT_DATABASE_FILE_NAME_HERE _context;

        public EFTaskRepository(PUT_DATABASE_FILE_NAME_HERE temp)
        {
            _context = temp;
        }

        //this might actually be categories not tasks? I am a little confused on this
        public List<System.Threading.Tasks.Task> Tasks => _context.Tasks.ToList();


        //we can call this in the controller to save/updated database
        public void AddTask(System.Threading.Tasks.Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}
