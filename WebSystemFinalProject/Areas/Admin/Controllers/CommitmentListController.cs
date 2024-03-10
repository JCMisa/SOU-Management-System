using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace WebSystemFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommitmentListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitmentListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CommitmentForm> commitmentForms = _unitOfWork.Commitment.GetAll(includeProperties: "College,AcademicRank").ToList();
            return View(commitmentForms);
        }





        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<CommitmentForm> commitmentForms = _unitOfWork.Commitment.GetAll(includeProperties: "College,AcademicRank").ToList();
            return Json(new { data = commitmentForms });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var commitmentToDelete = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);
            if (commitmentToDelete == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _unitOfWork.Commitment.Remove(commitmentToDelete);
            _unitOfWork.SaveChanges();
            TempData["success"] = "Commitment Form deleted successfully"; //for toaster before redirecting
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
