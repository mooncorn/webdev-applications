using System.ComponentModel.DataAnnotations;

namespace WebApiTasks.Models
{
    public class SessionModel
    {
        [Key]
        public string Token { get; set; }
        [Required]
        public string Email { get; set; }

        public SessionModel() 
        {
            Token = Guid.NewGuid().ToString();
        }
    }
}
