using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0414.Models
{
    public class SubmittedTaskContext : DbContext
    {
        // DbContext
        public SubmittedTaskContext(DbContextOptions<SubmittedTaskContext> options) : base(options) { }

        public DbSet<SubmittedTask> SubmittedTasks { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
