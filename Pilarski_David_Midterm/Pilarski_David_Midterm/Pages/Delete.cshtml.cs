using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pilarski_David_Midterm.Data;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(string id)
        {
            Product = _context.Products.Find(id);
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var productToDelete = _context.Products.Find(id);

            if (productToDelete != null)
            {
                _context.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
