using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

    }
}
