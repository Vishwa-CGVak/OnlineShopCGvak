using CGVAK_OnlineShop.DataAccess.Data;
using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart shopping)
        {
            _db.Update(shopping);
        }

        public int DecrementCount(ShoppingCart shopingCart, int count)
        {
            shopingCart.Count -= count;
            
            return shopingCart.Count;   
        }

        public int IncrementCount(ShoppingCart shopingCart, int count)
        {
            shopingCart.Count += count;

            return shopingCart.Count;
        }
    }
}
