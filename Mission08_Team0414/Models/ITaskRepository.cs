namespace Mission08_Team0414.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        //we need it for both tables
        List<Category> Category { get; }
    }
}
