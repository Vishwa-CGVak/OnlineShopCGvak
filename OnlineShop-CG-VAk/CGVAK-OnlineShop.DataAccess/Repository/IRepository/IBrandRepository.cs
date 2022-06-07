using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.DataAccess.Repository.IRepository
{
    public interface IBrandRepository: IRepository<Brand>
    {
        void Update(Brand brand);

    }
}
