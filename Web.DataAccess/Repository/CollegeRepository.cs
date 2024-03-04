using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Data;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace Web.DataAccess.Repository
{
    public class CollegeRepository : Repository<College>, ICollegeRepository
    {
        private ApplicationDbContext _db;

        public CollegeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(College college)
        {
            _db.Colleges.Update(college);
        }
    }
}
