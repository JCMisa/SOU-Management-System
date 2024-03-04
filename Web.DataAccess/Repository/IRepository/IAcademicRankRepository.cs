using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.IRepository
{
    public interface IAcademicRankRepository : IRepository<AcademicRank>
    {
        void Update(AcademicRank rank);
    }
}
