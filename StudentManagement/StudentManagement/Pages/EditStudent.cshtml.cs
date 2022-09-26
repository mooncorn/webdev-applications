using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class EditStudentModel : PageModel
    {
        public Student? student;

        public async Task<ActionResult> OnGet(string StudentNumber)
        {
            if (Data.GetInstance().User?.StudentNumber != StudentNumber) 
                return RedirectToPage("Index", new { Error = "Unauthorized" });

            student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);
            return Page();
        }

        public async Task<ActionResult> OnPost(string StudentNumber, string FullName, string Email, string Password, string Picture)
        {
            if (Data.GetInstance().User?.StudentNumber != StudentNumber)
                return RedirectToPage("Index", new { Error = "Unauthorized" });

            student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);

            if (student == null)
                return BadRequest("Student does not exist");

            student.ChangePassword(Password);
            student.FullName = FullName;
            student.Email = Email;
            student.Picture = Picture;

            return Redirect("/");
        }
    }
}
