using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public string StudentNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

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
