using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pilarski_David_Midterm.Data;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
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
