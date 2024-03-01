﻿namespace Mission08_Team0414.Models
{
    public interface ITaskRepository
    {
        List<SubmittedTask> SubmittedTasks { get; }

        public void AddSubmittedTask(SubmittedTask task);
        public void DeleteSubmittedTask(SubmittedTask task);
        public void EditSubmittedTask(SubmittedTask task);

        //we need it for both tables
        List<Category> Category { get; }
    }
}
