using System.ComponentModel.DataAnnotations;

namespace WebApiTasks.Models
{
    public class UserModel
    {
        [Key]
        public string Uid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public UserModel()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
