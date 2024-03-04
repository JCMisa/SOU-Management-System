using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //for college model
        public DbSet<College> Colleges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>().HasData(
                new College { CollegeId = 1, CollegeName = "COLLEGE OF ARTS AND SCIENCES (CAS)" },
                new College { CollegeId = 2, CollegeName = "COLLEGE OF BUSINESS, ADMINISTRATION AND ACCOUNTANCY (CBAA)" }
                );
        }

        //for academicRank model
        public DbSet<AcademicRank> AcademicRanks { get; set; }

        //for commitmentForm model
        public DbSet<CommitmentForm> CommitmentForms { get; set; }
    }
}
