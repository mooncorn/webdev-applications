using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class EditStudentModel : PageModel
    {
        public Student? student;

        public void OnGet(string StudentNumber)
        {
            student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);
        }

        public async Task<ActionResult> OnPost(string StudentNumber, string FullName, string Email, string Password, string Picture)
        {
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
