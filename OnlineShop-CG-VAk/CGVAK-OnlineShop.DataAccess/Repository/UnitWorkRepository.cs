using CGVAK_OnlineShop.DataAccess.Data;
using CGVAK_OnlineShop.DataAccess.Repository.IRepository;

namespace CGVAK_OnlineShop.DataAccess.Repository;

public class UnitWorkRepository : IUnitWorkRepository
{

    private readonly ApplicationDbContext _db;


    public ICategoryRepository Category { get;private set; }

    public IBrandRepository Brand { get; private set; }

    public IProductRepository Product { get; private set; }

    public IShoppingCartRepository ShoppingCart { get; private set; }

    

    public UnitWorkRepository(ApplicationDbContext db)
        {
        _db = db;
        Category = new CategoryRepository(_db);
        Brand = new BrandRepository(_db);    
        Product = new ProductRepository(_db);
        ShoppingCart = new ShoppingCartRepository(_db);

    }
    public void Save()
    {
        _db.SaveChanges();

    }
}
