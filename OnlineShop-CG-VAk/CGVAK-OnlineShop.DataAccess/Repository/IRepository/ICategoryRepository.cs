using CGVAK_OnlineShop.Models.Models;

namespace CGVAK_OnlineShop.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category category);

    }
}
