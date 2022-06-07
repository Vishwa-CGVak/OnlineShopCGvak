using Microsoft.EntityFrameworkCore;
using CGVAK_OnlineShop.Models.Models;


namespace CGVAK_OnlineShop.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCart> ShopingCarts { get; set; }
    }
}
