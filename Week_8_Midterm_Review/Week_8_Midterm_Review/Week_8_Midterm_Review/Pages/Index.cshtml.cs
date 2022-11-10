using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week_8_Midterm_Review.Data;
using Week_8_Midterm_Review.Models;

namespace Week_8_Midterm_Review.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _context;

        public List<Product> Products { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}