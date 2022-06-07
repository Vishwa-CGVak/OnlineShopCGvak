using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop_CG_VAk.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitWorkRepository _unitOfWork;

        public CategoryController(IUnitWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();

            return View(categoryList);
        }
        public IActionResult Create()
        {

            Category category = new Category();


            var categoryDb = _unitOfWork.Category.GetAll().OrderBy(c => c.OrderOfDisplay).LastOrDefault(c => c.OrderOfDisplay == (int)_unitOfWork.Category.GetAll().Max(c => c.OrderOfDisplay));

            if (categoryDb == null)
            {
                category.Name = "";
                category.OrderOfDisplay = 1;

                return View(category);
            }
            else
            {
                categoryDb.Name = "";
                categoryDb.OrderOfDisplay = categoryDb.OrderOfDisplay + 1;

                return View(categoryDb);
            }


        }

        [HttpPost]
        public IActionResult Create(Category ctry)

        {
            if (ModelState.IsValid)
            {
                var checkData = _unitOfWork.Category.GetFirstOrDefault(p => p.Name == ctry.Name || p.OrderOfDisplay == ctry.OrderOfDisplay);

                if (checkData != null)
                {
                    TempData["AlreadyExists"] = "Category/Order of Display Already Exists!";

                    return RedirectToAction("Index");

                }
                else
                {
                    _unitOfWork.Category.Add(ctry);

                    _unitOfWork.Save();

                    TempData["Create"] = "Category Created Successfully";

                    return RedirectToAction("Index");

                }

            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            var fetchDetails = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            return View(fetchDetails);
        }

        [HttpPost]
        public IActionResult Edit(Category ctry)

        {
            if (ModelState.IsValid)
            {

                var checkData = _unitOfWork.Category.GetFirstOrDefault(p => p.Name == ctry.Name && p.OrderOfDisplay == ctry.OrderOfDisplay);

                if (checkData != null)
                {
                    TempData["NoChanges"] = "No Changes Detected!";

                    return RedirectToAction("Index");

                }
                else
                {
                    _unitOfWork.Category.Update(ctry);

                    _unitOfWork.Save();

                    TempData["Update"] = "Category Updated Successfully";

                    return RedirectToAction("Index");

                }

            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            var test = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);

            return View(test);
        }

        [HttpPost]
        public ActionResult Delete(int id, Category ctry)
        {
            try
            {
                _unitOfWork.Category.Remove(ctry);

                _unitOfWork.Save();

                TempData["Delete"] = "Category Deleted Successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
