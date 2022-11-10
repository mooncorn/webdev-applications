using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week_8_Midterm_Review.Data;
using Week_8_Midterm_Review.Models;

namespace Week_8_Midterm_Review.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext db) {
            _context = db;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            Product = _context.Products.Find(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(Product);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
