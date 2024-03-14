using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICollegeRepository College { get; }

        IAcademicRankRepository AcademicRank { get; }

        IAcademicYearRepository AcademicYear { get; }

        ICommitmentRepository Commitment { get; }

        void SaveChanges();
    }
}
