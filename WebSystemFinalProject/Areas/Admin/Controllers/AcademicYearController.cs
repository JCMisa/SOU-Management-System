using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebSystemFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Super_Admin)]
    public class AcademicYearController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicYearController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<AcademicYear> academicYears = _unitOfWork.AcademicYear.GetAll().ToList();
            if (academicYears == null)
                return NotFound();
            else
                return View(academicYears);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AcademicYearId, YearName")] AcademicYear year)
        {
            if(year == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _unitOfWork.AcademicYear.Add(year);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Year added successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(year);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var yearObj = _unitOfWork.AcademicYear.Get(u => u.AcademicYearId == id);

            if (yearObj == null) return NotFound();

            return View(yearObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("AcademicYearId, YearName")] AcademicYear year)
        {
            if (id == null || year == null) return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.AcademicYear.Update(year);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Academic year updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(year);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var yearObj = _unitOfWork.AcademicYear.Get(u => u.AcademicYearId == id);

            if (yearObj == null) return NotFound();

            return View(yearObj);
        }




        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var yearObj = _unitOfWork.AcademicYear.Get(u => u.AcademicYearId == id);

            if (yearObj == null) return NotFound();

            _unitOfWork.AcademicYear.Remove(yearObj);
            _unitOfWork.SaveChanges();
            TempData["success"] = "Academic year deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
