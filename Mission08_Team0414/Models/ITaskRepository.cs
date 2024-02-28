namespace Mission08_Team0414.Models
{
    public interface ITaskRepository
    {
        List<System.Threading.Tasks.Task> Tasks { get; }

        public void AddTask(System.Threading.Tasks.Task task);
    }
}
