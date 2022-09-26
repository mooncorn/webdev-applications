using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Student> Students { get; set; }
        public string Error = String.Empty;
        public bool HasError { get { return Error != null && Error != String.Empty; } }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Students = Data.GetInstance().students;
        }

        public void OnGet(string Error)
        {
            this.Error = Error;
        }
    }
}