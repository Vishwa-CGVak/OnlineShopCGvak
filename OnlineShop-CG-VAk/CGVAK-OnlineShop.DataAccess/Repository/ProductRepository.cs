using CGVAK_OnlineShop.DataAccess.Data;
using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;

namespace CGVAK_OnlineShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Product product)
        {
            _db.Update(product);
        }
    }
}
