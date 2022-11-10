using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week_8_Midterm_Review.Data;
using Week_8_Midterm_Review.Models;

namespace Week_8_Midterm_Review.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext db) {
            _context = db;
        }

        public void OnGet(string id)
        {
            Product = _context.Products.Find(id);
        }

        public async Task<IActionResult> OnPost() {
            var productToDelete = _context.Products.Find(Product.Id);
            if (productToDelete != null) {
                _context.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
