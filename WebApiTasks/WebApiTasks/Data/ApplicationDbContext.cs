using Microsoft.EntityFrameworkCore;
using WebApiTasks.Models;

namespace WebApiTasks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }
    }
}
