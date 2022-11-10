using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student Number")]
        [StringLength(10)]
        public string StudentNumber { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Picture { get; set; }

        public Student() { }

        public Student(string studentNumber, string fullName, string email, string password, string picture)
        {
            StudentNumber = studentNumber;
            FullName = fullName;
            Email = email;
            Password = password;
            Picture = picture;
        }

        public bool IsPasswordValid(string password)
        {
            return Password == password;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
