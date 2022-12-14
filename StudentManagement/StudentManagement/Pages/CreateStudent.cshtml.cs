using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.DataSource;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        private readonly ApplicationDbContext _context;

        public CreateStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost(Student student)
        {
            if (ModelState.IsValid)
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
