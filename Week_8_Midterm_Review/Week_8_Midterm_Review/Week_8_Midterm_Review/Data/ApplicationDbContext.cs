using Microsoft.EntityFrameworkCore;
using Week_8_Midterm_Review.Models;

namespace Week_8_Midterm_Review.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        public DbSet<Product> Products { get; set; }
    }
}
