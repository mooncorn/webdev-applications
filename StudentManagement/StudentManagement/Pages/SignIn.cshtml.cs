using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;

namespace StudentManagement.Pages
{
    public class SignInModel : PageModel
    {
        public string ErrorMessage = String.Empty;
        public bool HasMessage { get { return ErrorMessage != null && ErrorMessage != String.Empty; } }

        public string StudentNumber = String.Empty;

        public void OnGet(string ErrorMessage, string StudentNumber)
        {
            this.ErrorMessage = ErrorMessage;
            this.StudentNumber = StudentNumber;
        }

        public async Task<ActionResult> OnPost(string StudentNumber, string Password)
        {
            var student = Data.GetInstance().students.Find(s => s.StudentNumber == StudentNumber);

            if (student != null && student.IsPasswordValid(Password))
            {
                Data.GetInstance().User = student;
                return Redirect("/");
            } 
            else
            {
                return RedirectToPage("SignIn", new { ErrorMessage = "Student Number or Password is invalid" });
            }
        }
    }
}
