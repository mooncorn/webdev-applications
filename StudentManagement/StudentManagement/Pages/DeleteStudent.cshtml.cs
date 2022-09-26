using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class DeleteStudentModel : PageModel
    {
        public Student? student;

        public void OnGet(string StudentNumber)
        {
            student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);
        }

        public async Task<ActionResult> OnPost(string StudentNumber)
        {
            Data.GetInstance().students.RemoveAll(s => s.StudentNumber == StudentNumber);
            return Redirect("/");
        }
    }
}
