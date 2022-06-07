using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;
using CGVAK_OnlineShop.Models.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CG_VAK_BooksWeb.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitWorkRepository unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> ProductsList = _unitOfWork.Product.GetAll();

            return View(ProductsList);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVm obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                var wwwRootpath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(file.FileName);
                    var uploadpath = Path.Combine(wwwRootpath, @"images\products\");
                    if (obj.product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootpath, obj.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploadpath, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.product.ImageUrl = fileName + extension;
                }
                if (obj.product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.product);
                }

                _unitOfWork.Save();

                if (obj.product.Id == 0)
                {
                    TempData["Create"] = "Product Created successfully";
                }
                else
                {
                    TempData["Update"] = "Product Updated successfully";
                }
                
                return RedirectToAction("index");
            }

            return View();

        }

        public IActionResult Upsert(int? Id)
        {
            ProductVm productVm = new()
            {
                product = new(),
                categoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                brandList = _unitOfWork.Brand.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })

            };


            if (Id == null || Id == 0)
            {

                return View(productVm);
            }
            else
            {

                productVm.product = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == Id);

                return View(productVm);
            }



            }
        [HttpPost]
        public IActionResult Delete(ProductVm productVm)
        {

            if (ModelState.IsValid)
            {
                if (productVm.product.Id != 0)
                {
                    TempData["success"] = "Product Deletd successfully";
                    _unitOfWork.Product.Remove(productVm.product);
                    _unitOfWork.Save();
                }
                else
                {
                    TempData["Info"] = "Nothing is Deleted";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int? Id)
        {
            ProductVm productVm = new()
            {
                product = new(),
                categoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                brandList = _unitOfWork.Brand.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };


            if (Id != 0)
            {
                productVm.product = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == Id);

                return View(productVm);
            }
            return View(productVm);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category,BrandType");
            return Json(new { status = "Sucess", data = productList });
        }

        /*#region Implementation for API calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList=_unitOfWork.ProductRepository.GetAll();
            return Json(new { status = "Sucess", data = productList });
        }
        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            if(Id == null)
            {
                return Json(new { status = "Failed", message = "Deletion  of Product failed" });
            }
            var obj=_unitOfWork.ProductRepository.GetFirstOrDefault(c=>c.Id== Id);
            if(Id != null)
            {
              _unitOfWork.ProductRepository.Remove(obj);
                _unitOfWork.save();
                return Json(new { staus = "success",message="product Deleted succussfully.."});
            }
            else
            {
                return Json(new { staus = "Failes", message = "product Deleted Failed Product not Found.." });
            }
            
        }
        #endregion*/
    }
}