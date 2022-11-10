using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week_8_Midterm_Review.Data;
using Week_8_Midterm_Review.Models;

namespace Week_8_Midterm_Review.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext db) {
            _context = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {

                await _context.Products.AddAsync(Product);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }

    }
}
