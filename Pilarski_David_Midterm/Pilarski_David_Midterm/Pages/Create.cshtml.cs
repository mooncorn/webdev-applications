using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pilarski_David_Midterm.Data;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(Product);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
