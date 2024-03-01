namespace Mission08_Team0414.Models
{
    // Interface declaration
    public interface ITaskRepository
    {
        // Properties
        List<SubmittedTask> SubmittedTasks { get; }
        List<Category> Category { get; }

        // Methods
        public void AddSubmittedTask(SubmittedTask task);
        public void DeleteSubmittedTask(SubmittedTask task);
        public void EditSubmittedTask(SubmittedTask task);
    }
}
