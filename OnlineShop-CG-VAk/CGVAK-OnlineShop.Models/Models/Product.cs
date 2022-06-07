using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CGVAK_OnlineShop.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name ="Model No")]
        public string? ISBN { get; set; }
        [Required]
        [Display(Name = "Manufactured By")]
        public String Author { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 1-50")]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 51-100")]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [ValidateNever]
        public Category? Category { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        [ValidateNever]
        public Brand? BrandType { get; set; }

    }
}
