using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Models.ViewModels;
using Web.Utility;

namespace WebSystemFinalProject.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = StaticDetails.Role_Super_Admin + ", " + StaticDetails.Role_Admin + ", " + StaticDetails.Role_User)]
    public class CommitmentFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitmentFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || _unitOfWork.Commitment == null)
            {
                return NotFound();
            }

            var commitmentObj = _unitOfWork.Commitment.Get(u => u.CommitmentId == id, includeProperties: "College,AcademicRank");

            if (commitmentObj == null)
            {
                return NotFound();
            }

            return View(commitmentObj);
        }




        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CommitmentFormVM cmVM = new()
            {
                CollegeList = _unitOfWork.College.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.CollegeName,
                    Value = u.CollegeId.ToString()
                }),
                AcademicRankList = _unitOfWork.AcademicRank.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.RankName,
                    Value = u.AcademicRankId.ToString()
                }),
                CommitmentForm = new CommitmentForm(),
            };
            
            if(id == null || id == 0)
            {
                // create
                return View(cmVM);
            }
            else
            {
                // update
                cmVM.CommitmentForm = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);
                return View(cmVM);
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CommitmentFormVM commitmentFormVM)
        {
            if (commitmentFormVM.CommitmentForm == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                if(commitmentFormVM.CommitmentForm.CommitmentId == 0)
                {
                    _unitOfWork.Commitment.Add(commitmentFormVM.CommitmentForm);
                    TempData["success"] = "Commitment Form added successfully";
                }
                else
                {
                    _unitOfWork.Commitment.Update(commitmentFormVM.CommitmentForm);
                    TempData["success"] = "Commitment Form updated successfully";
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("Details", new { id = commitmentFormVM.CommitmentForm.CommitmentId });
            }
            else
            {
                commitmentFormVM.CollegeList = _unitOfWork.College.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.CollegeName,
                    Value = u.CollegeId.ToString()
                });
                commitmentFormVM.AcademicRankList = _unitOfWork.AcademicRank.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.RankName,
                    Value = u.AcademicRankId.ToString()
                });

                return View(commitmentFormVM);
            }         
        }



        public IActionResult Delete(int? id)
        {
            CommitmentFormVM cmVM = new()
            {
                CollegeList = _unitOfWork.College.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.CollegeName,
                    Value = u.CollegeId.ToString()
                }),
                AcademicRankList = _unitOfWork.AcademicRank.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.RankName,
                    Value = u.AcademicRankId.ToString()
                }),
                CommitmentForm = new CommitmentForm(),
            };

            // delete
            cmVM.CommitmentForm = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);
            return View(cmVM);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            if (_unitOfWork == null)
            {
                return Problem("Entity set 'IUnitOfWork'  is null.");
            }
            CommitmentForm? category = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);
            if (category != null)
            {
                _unitOfWork.Commitment.Remove(category);
            }

            _unitOfWork.SaveChanges();
            TempData["success"] = "Commitment Form deleted successfully"; //for toaster before redirecting
            return RedirectToAction("Index", "Home");
        }

    }
}
