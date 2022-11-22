using Data;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cms.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitofWork _unitOfWork;
        public ProductController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        //Get
        //public IActionResult Create()
        //{
        //    return View();
        //}
        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(SubCategory obj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _unitOfWork.SubCategory.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["Success"] = "SubCategory successfully Added";
        //        return RedirectToAction("Create");

        //    }
        //    return View(obj);
        //}
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> SubCategoryList = _unitOfWork.SubCategory.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }
            );
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString(),
            //    }
            //);
            if (id == null || id == 0)
            {
                List<SelectListItem> selectListItem = new List<SelectListItem>();
                foreach (var subCategory in SubCategoryList)
                {
                    selectListItem.Add(subCategory);
                }
                ViewBag.SubCategoryList = selectListItem;
                return View(product);
            }
            //update
            else
            {
                product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
                return View(product);
            }
            //var subcategoryfromDbFirst = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
            //if (subcategoryfromDbFirst == null)
            //{
            //    return NotFound();
            //}
            

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {  
                if (obj.Id== 0)
                {
                    _unitOfWork.Product.Add(obj);
                   
                }
                else
                {

                    _unitOfWork.Product.Update(obj);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Product added successfully";
                return RedirectToAction("Index");

            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }


        //POST
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "errrorr while deleting" });
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Product Deleted successfully" });
            //TempData["Success"] = "Product Deleted successfully";
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties:"SubCategory,Category");
            return Json(new { data = productList });

        }

        #endregion

    }
}



