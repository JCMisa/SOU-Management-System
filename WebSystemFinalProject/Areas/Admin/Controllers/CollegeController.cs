using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebSystemFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Super_Admin)]
    public class CollegeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollegeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<College> colleges = _unitOfWork.College.GetAll().ToList();

            if (colleges == null)
                return NotFound();
            else
                return View(colleges);
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CollegeId, CollegeName")] College college)
        {
            if (college == null) return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.College.Add(college);
                _unitOfWork.SaveChanges();
                TempData["success"] = "College added successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(college);
        }





        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var collegeObj = _unitOfWork.College.Get(u => u.CollegeId == id);

            if (collegeObj == null) return NotFound();

            return View(collegeObj);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("CollegeId, CollegeName")] College college)
        {
            if (id == null || college == null) return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.College.Update(college);
                _unitOfWork.SaveChanges();
                TempData["success"] = "College updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(college);
        }




        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var collegeObj = _unitOfWork.College.Get(u => u.CollegeId == id);

            if (collegeObj == null) return NotFound();

            return View(collegeObj);
        }




        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var collegeObj = _unitOfWork.College.Get(u => u.CollegeId == id);

            if (collegeObj == null) return NotFound();

            _unitOfWork.College.Remove(collegeObj);
            _unitOfWork.SaveChanges();
            TempData["success"] = "College deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
