using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Models.ViewModels;

namespace WebSystemFinalProject.Areas.User.Controllers
{
    [Area("User")]
    public class CommitmentFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitmentFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public IActionResult Index()
        {
            List<CommitmentForm> commitmentForms = _unitOfWork.Commitment.GetAll(includeProperties: "College,AcademicRank").ToList();
            //IEnumerable<SelectListItem> CollegeList = _unitOfWork.College.
            //    GetAll().Select(u => new SelectListItem
            //    {
            //        Text = u.CollegeName,
            //        Value = u.CollegeId.ToString()
            //    });
            return View(commitmentForms);
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



        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if(id == null)
        //    {
        //        return NotFound();
        //    }

        //    var commitmentObj = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);

        //    if(commitmentObj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(commitmentObj);
        //}


        ////#region API CALLS
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteCommitment(int? id)
        //{
        //    var commitmentObj = _unitOfWork.Commitment.Get(u => u.CommitmentId == id);
        //    if (commitmentObj == null)
        //    {
        //        //return Json(new { success = false, message = "Error While Deleting" });
        //        return NotFound();
        //    }

        //    _unitOfWork.Commitment.Remove(commitmentObj);
        //    _unitOfWork.SaveChanges();
        //    TempData["success"] = "Commitment Form deleted successfully"; //for toaster before redirecting
        //    //return Json(new { success = true, message = "Delete Successful" });
        //    return RedirectToAction("Index", "Home");
        //}
        ////#endregion
    }
}
