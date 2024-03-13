using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebSystemFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Super_Admin)]
    public class AcademicRankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicRankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<AcademicRank> academicRanks = _unitOfWork.AcademicRank.GetAll().ToList();
            if (academicRanks == null)
                return NotFound();
            else
                return View(academicRanks);
        }







        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AcademicRankId, RankName")] AcademicRank acadRank)
        {
            if (acadRank == null) return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.AcademicRank.Add(acadRank);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Academic rank added successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(acadRank);
        }






        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var rankObj = _unitOfWork.AcademicRank.Get(u => u.AcademicRankId == id);

            if (rankObj == null) return NotFound();

            return View(rankObj);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("AcademicRankId, RankName")] AcademicRank acadRank)
        {
            if (id == null || acadRank == null) return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.AcademicRank.Update(acadRank);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Academic rank updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(acadRank);
        }





        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return BadRequest();

            var rankObj = _unitOfWork.AcademicRank.Get(u => u.AcademicRankId == id);

            if (rankObj == null) return NotFound();

            return View(rankObj);
        }




        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var rankObj = _unitOfWork.AcademicRank.Get(u => u.AcademicRankId == id);

            if (rankObj == null) return NotFound();

            _unitOfWork.AcademicRank.Remove(rankObj);
            _unitOfWork.SaveChanges();
            TempData["success"] = "Academic rank deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
