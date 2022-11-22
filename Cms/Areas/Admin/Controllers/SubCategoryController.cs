using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitofWork _unitOfWork;
        public SubCategoryController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<SubCategory>? objCategoryList = _unitOfWork.SubCategory.GetAll();
            return View(objCategoryList);
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
            SubCategory subCategory = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u=> new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }
            );
            if (id == null || id == 0)
            {
                ViewBag.CategoryList = CategoryList;
                return View(subCategory);
            }
            else
            {  //var subcategoryfromDbFirst = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
                //if (subcategoryfromDbFirst == null)
                //{
                //    return NotFound();
                //}
                subCategory = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);

                return View(subCategory);
            }
            return View(subCategory);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SubCategory obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                _unitOfWork.SubCategory.Add(obj);

            }
                else
            {

                _unitOfWork.SubCategory.Update(obj);
            }
            _unitOfWork.Save();
            TempData["Success"] = "SubCategory added successfully";
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
            var categoryfromDb = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            { return NotFound(); }
            _unitOfWork.SubCategory.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "SubCategory Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

