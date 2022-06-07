using CGVAK_OnlineShop.DataAccess.Repository.IRepository;
using CGVAK_OnlineShop.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop_CG_VAk.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private readonly IUnitWorkRepository _unitOfWork;

        public BrandController(IUnitWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Brand> brandList = _unitOfWork.Brand.GetAll();

            return View(brandList);
        }
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(Brand brnd)

        {
            if (ModelState.IsValid)
            {
                var checkData = _unitOfWork.Brand.GetFirstOrDefault(p => p.Name == brnd.Name);

                if (checkData != null)
                {
                    TempData["AlreadyExists"] = $"'{brnd.Name}' Brand Already Exists!";

                    return RedirectToAction("Index");

                }
                else
                {
                    _unitOfWork.Brand.Add(brnd);

                    _unitOfWork.Save();

                    TempData["Create"] = $"'{brnd.Name}' Brand Created Successfully";

                    return RedirectToAction("Index");

                }

            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            var fetchDetails = _unitOfWork.Brand.GetFirstOrDefault(c => c.Id == id);
            return View(fetchDetails);
        }

        [HttpPost]
        public IActionResult Edit(Brand brnd)

        {
            if (ModelState.IsValid)
            {

                var checkData = _unitOfWork.Brand.GetFirstOrDefault(p => p.Name == brnd.Name);

                if (checkData != null)
                {
                    TempData["NoChanges"] = "No Changes Detected!";

                    return RedirectToAction("Index");

                }
                else
                {
                    _unitOfWork.Brand.Update(brnd);

                    _unitOfWork.Save();

                    TempData["Update"] = $"'{brnd.Name}' Brand Updated Successfully";

                    return RedirectToAction("Index");

                }

            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            var test = _unitOfWork.Brand.GetFirstOrDefault(c => c.Id == id);

            return View(test);
        }

        [HttpPost]
        public ActionResult Delete(int id, Brand brnd)
        {
            try
            {


                _unitOfWork.Brand.Remove(brnd);

                _unitOfWork.Save();

                TempData["Delete"] = "Brnad Deleted Successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
