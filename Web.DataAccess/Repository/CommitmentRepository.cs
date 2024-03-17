using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace Web.DataAccess.Repository
{
    public class CommitmentRepository : Repository<CommitmentForm>, ICommitmentRepository
    {
        private ApplicationDbContext _db;

        public CommitmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CommitmentForm commitmentForm)
        {
            //_db.CommitmentForms.Update(commitmentForm);
            var objFromDb = _db.CommitmentForms.FirstOrDefault(u => u.CommitmentId == commitmentForm.CommitmentId);
            if (objFromDb != null)
            {
                objFromDb.OrganizationName = commitmentForm.OrganizationName;
                objFromDb.SchoolYear = commitmentForm.SchoolYear;
                objFromDb.AdvicerName = commitmentForm.AdvicerName;
                objFromDb.HomeAddress = commitmentForm.HomeAddress;
                objFromDb.ContactNo = commitmentForm.ContactNo;
                objFromDb.CollegeId = commitmentForm.CollegeId;
                objFromDb.AcademicRankId = commitmentForm.AcademicRankId;
            }
        }
    }
}
