using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models; 

namespace TaskManagementSystem.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) {}

        public DbSet<TaskItem> TaskItems {get; set;}
    }

}