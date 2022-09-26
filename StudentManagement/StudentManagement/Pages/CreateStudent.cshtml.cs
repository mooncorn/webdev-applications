using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class CreateStudentModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost(string StudentNumber, string FullName, string Email, string Password, string Picture)
        {
            Data.GetInstance().students.Add(new(StudentNumber, FullName, Email, Password, Picture));
            return RedirectToPage("Index");
        }
    }
}
