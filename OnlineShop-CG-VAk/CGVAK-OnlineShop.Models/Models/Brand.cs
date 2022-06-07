using System.ComponentModel.DataAnnotations;

namespace CGVAK_OnlineShop.Models.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
