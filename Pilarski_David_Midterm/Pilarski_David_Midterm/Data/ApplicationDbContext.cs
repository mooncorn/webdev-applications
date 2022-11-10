using Microsoft.EntityFrameworkCore;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
