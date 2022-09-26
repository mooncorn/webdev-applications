using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;

namespace StudentManagement.Pages
{
    public class SignOutModel : PageModel
    {
        public async Task<ActionResult> OnGet()
        {
            Data.GetInstance().User = null;
            return RedirectToPage("Index");
        }
    }
}
