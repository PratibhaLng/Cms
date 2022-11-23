using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            IEnumerable<SubCategory> objCategoryList = _unitOfWork.SubCategory.GetAll(includeProperties: "Category"); ;

            
            //ViewBag.CategoryList = CategoryList;


            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
               u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString(),
               }
           );
            ViewBag.CategoryList = CategoryList;

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory obj)
        {
            if (!ModelState.IsValid)
            {
            _unitOfWork.SubCategory.Add(obj);
            _unitOfWork.Save();
            TempData["Success"] = "SubCategory successfully Added";
            return RedirectToAction("Create");

            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            SubCategory subCategory = new();

            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
               u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString(),
               }
           );
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                subCategory = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
                ViewBag.CategoryList = CategoryList;
                return View(subCategory);
            }
            

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory obj)
        {
           //// if (ModelState.IsValid)
           // {
                if (obj.Id != 0)
                {
                    _unitOfWork.SubCategory.Update(obj);
                }



                _unitOfWork.Save();
                TempData["Success"] = "SubCategory updated successfully";

                return RedirectToAction("Index");


           // }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
              u => new SelectListItem
              {
                  Text = u.Name,
                  Value = u.Id.ToString(),
              }
          );
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = CategoryList;
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

