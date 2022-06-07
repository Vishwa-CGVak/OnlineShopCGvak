using CGVAK_OnlineShop.DataAccess.Repository;
using CGVAK_OnlineShop.Models.View_Model;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop_CG_VAk.Areas.Customer.Controllers
{
    public class CartController : Controller
    {

        private readonly UnitWorkRepository _unitWork;

        public CartController(UnitWorkRepository unitWork)
        {
            _unitWork = unitWork;
        }
        public IActionResult CartIndex()
        {
            var shoppingCartVm = new ShoppingCartVm()
            {
                ListCart = _unitWork.ShoppingCart.GetAll(includeProperties : "product"),
                OrderHeader = new()

            };
            foreach (var cart in shoppingCartVm.ListCart)
            {
                cart.price = GetPriceBasedOntheQuentity(cart.Count, cart.product.Price,

                    cart.product.Price50, cart.product.Price100);


                shoppingCartVm.OrderHeader.OrderTotal += (cart.price * cart.Count);

            }

            return View(shoppingCartVm);
        }

        private double GetPriceBasedOntheQuentity(double quantity, double price, double price50, double price100)
        {
            if(quantity <= 50)
            {
                return price;
            }
            else
            {
                if(quantity <= 100)
                {
                    return price50;
                }               
                
                return price100;
                
            }
        }
    }
}
