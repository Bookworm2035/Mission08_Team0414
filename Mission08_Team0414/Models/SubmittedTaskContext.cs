﻿using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0414.Models
{
    public class SubmittedTaskContext : DbContext
    {
        public SubmittedTaskContext(DbContextOptions<SubmittedTaskContext> options) : base(options) { }

        public DbSet<SubmittedTask> SubmittedTasks { get; set; }

        //added this cus we need to use this for category table
        public DbSet<Category> Category { get; set; }
    }
}
