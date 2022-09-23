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

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Students = Data.GetInstance().students;
        }

        public void OnGet()
        {

        }
    }
}