using System.ComponentModel.DataAnnotations;

namespace Week_8_Midterm_Review.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        public Product() {
        
        }
    }
}
