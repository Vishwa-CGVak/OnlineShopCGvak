using CGVAK_OnlineShop.DataAccess.Data;
using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;

namespace CGVAK_OnlineShop.DataAccess.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Brand brand)
        {
            _db.Update(brand);
        }
    }
}
