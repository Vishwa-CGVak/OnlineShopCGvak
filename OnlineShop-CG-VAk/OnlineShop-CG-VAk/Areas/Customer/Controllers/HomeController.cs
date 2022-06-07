using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop_CG_VAk.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitWorkRepository _unitWork;

        public HomeController(ILogger<HomeController> logger, IUnitWorkRepository unitWork)
        {
            _logger = logger;
            _unitWork = unitWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitWork.Product.GetAll();


            return View(productList);
        }


        public IActionResult Details(int productId)
        {
            ShoppingCart shopingCart = new()
            {
                ProductId = productId,
                product = _unitWork.Product.GetFirstOrDefault(p => p.Id == productId),
                Count = 1
            };

            return View(shopingCart);
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shopingCart)
        {
            ShoppingCart cartFromDb = _unitWork.ShoppingCart.GetFirstOrDefault(
                
                u => u.Id == shopingCart.ProductId);

            if(cartFromDb == null)
            {
                _unitWork.ShoppingCart.Add(shopingCart);
                _unitWork.Save();
                //HttpContext.Session.SetInt32(AppConstants.SessionCart, _unitWork.ShopingCart.GetAll().ToList().Count());
            }
            else
            {
                _unitWork.ShoppingCart.IncrementCount(cartFromDb,shopingCart.Count);
                _unitWork.Save();
            }


            return RedirectToAction("Index"); ;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
