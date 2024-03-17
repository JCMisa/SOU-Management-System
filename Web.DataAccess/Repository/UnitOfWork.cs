using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.IRepository;

namespace Web.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICollegeRepository? College { get; private set; }
        public IAcademicRankRepository? AcademicRank { get; private set; }
        public ICommitmentRepository? Commitment { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            College = new CollegeRepository(_db);
            AcademicRank = new AcademicRankRepository(_db);
            Commitment = new CommitmentRepository(_db);
        }       

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
