using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.Models.View_Model
{
    public class ShoppingCartVm
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
