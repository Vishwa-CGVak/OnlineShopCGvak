using CGVAK_OnlineShop.DataAccess.Data;
using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;

        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
