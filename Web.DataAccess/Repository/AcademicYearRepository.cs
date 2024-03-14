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
    public class AcademicYearRepository : Repository<AcademicYear>, IAcademicYearRepository
    {
        private ApplicationDbContext _db;

        public AcademicYearRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AcademicYear year)
        {
            _db.AcademicYears.Update(year);
        }
    }
}
