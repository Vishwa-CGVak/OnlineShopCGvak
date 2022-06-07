using CGVAK_OnlineShop.Models.Models;

namespace CGVAK_OnlineShop.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shopingCart, int count);
        int DecrementCount(ShoppingCart shopingCart, int count);
    }
}
