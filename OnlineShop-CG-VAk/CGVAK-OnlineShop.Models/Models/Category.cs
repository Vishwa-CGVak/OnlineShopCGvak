using System.ComponentModel.DataAnnotations;

namespace CGVAK_OnlineShop.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Order Of Display field is required")]
        [Range(1, 100, ErrorMessage = "Input value should be 1 to 100")]
        [Display(Name = "Order Of Display")]
        public int? OrderOfDisplay { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
