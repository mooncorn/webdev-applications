using System.ComponentModel.DataAnnotations;

namespace WebApiTasks.Models
{
    public class TaskModel
    {
        [Key]
        public string TaskUid { get; set; }
        [Required]
        public string CreatedByUid { get; set; }
        [Required]
        public string CreatedByName { get; set; }
        [Required]
        public string AssignedToUid { get; set; }
        [Required]
        public string AssignedToName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done { get; set; }

        public TaskModel() 
        {
            TaskUid = Guid.NewGuid().ToString();
            Done = false;
        }
    }
}
