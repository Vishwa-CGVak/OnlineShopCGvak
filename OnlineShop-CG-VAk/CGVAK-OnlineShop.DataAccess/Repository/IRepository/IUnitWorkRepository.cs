namespace CGVAK_OnlineShop.DataAccess.Repository.IRepository;

public interface IUnitWorkRepository
{
    ICategoryRepository Category { get; }
    IBrandRepository Brand { get; }

    IProductRepository Product { get; }

    IShoppingCartRepository ShoppingCart { get; }


    void Save();
}
