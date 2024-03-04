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
    public class AcademicRankRepository : Repository<AcademicRank>, IAcademicRankRepository
    {
        private ApplicationDbContext _db;

        public AcademicRankRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AcademicRank rank)
        {
            _db.AcademicRanks.Update(rank);
        }
    }
}
