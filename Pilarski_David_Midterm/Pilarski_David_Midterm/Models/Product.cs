using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pilarski_David_Midterm.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public string ProductId { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        [MaxLength(50)]
        public string ProductDescription { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Buy Price")]
        public double BuyPrice { get; set; }

        [Required]
        [Display(Name = "Sell Price")]
        public double SellPrice { get; set; }

        public Product()
        {

        }
    }
}
