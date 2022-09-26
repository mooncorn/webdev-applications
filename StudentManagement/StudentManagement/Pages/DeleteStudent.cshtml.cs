using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class DeleteStudentModel : PageModel
    {
        public Student? student;

        public async Task<ActionResult> OnGet(string StudentNumber)
        {
            if (Data.GetInstance().User?.StudentNumber != StudentNumber)
                return RedirectToPage("Index", new { Error = "Unauthorized" });

            student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);
            return Page();
        }

        public async Task<ActionResult> OnPost(string StudentNumber)
        {
            if (Data.GetInstance().User?.StudentNumber != StudentNumber)
                return RedirectToPage("Index", new { Error = "Unauthorized" });

            Data.GetInstance().students.RemoveAll(s => s.StudentNumber == StudentNumber);
            Data.GetInstance().User = null;

            return Redirect("/");
        }
    }
}
