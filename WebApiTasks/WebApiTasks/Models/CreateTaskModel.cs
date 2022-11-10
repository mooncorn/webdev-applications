using System.ComponentModel.DataAnnotations;

namespace WebApiTasks.Models
{
    public class CreateTaskModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AssignedToUid { get; set; }
    }
}
