using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CGVAK_OnlineShop.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CGVAK_OnlineShop.Models.View_Model
{
    public class ProductVm
    {
        public Product product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> categoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> brandList { get; set; }
    }
}
