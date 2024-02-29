using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0414.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

        //added this cus we need to use this for category table
        public DbSet<Category> Category { get; set; }
    }
}
