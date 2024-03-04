﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.DataAccess.Data;

#nullable disable

namespace Web.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web.Models.AcademicRank", b =>
                {
                    b.Property<int>("AcademicRankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicRankId"));

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicRankId");

                    b.ToTable("AcademicRanks");
                });

            modelBuilder.Entity("Web.Models.College", b =>
                {
                    b.Property<int>("CollegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollegeId"));

                    b.Property<string>("CollegeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollegeId");

                    b.ToTable("Colleges");

                    b.HasData(
                        new
                        {
                            CollegeId = 1,
                            CollegeName = "COLLEGE OF ARTS AND SCIENCES (CAS)"
                        },
                        new
                        {
                            CollegeId = 2,
                            CollegeName = "COLLEGE OF BUSINESS, ADMINISTRATION AND ACCOUNTANCY (CBAA)"
                        });
                });

            modelBuilder.Entity("Web.Models.CommitmentForm", b =>
                {
                    b.Property<int>("CommitmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitmentId"));

                    b.Property<int>("AcademicRankId")
                        .HasColumnType("int");

                    b.Property<string>("AdvicerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommitmentId");

                    b.HasIndex("AcademicRankId");

                    b.HasIndex("CollegeId");

                    b.ToTable("CommitmentForms");
                });

            modelBuilder.Entity("Web.Models.CommitmentForm", b =>
                {
                    b.HasOne("Web.Models.AcademicRank", "AcademicRank")
                        .WithMany()
                        .HasForeignKey("AcademicRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicRank");

                    b.Navigation("College");
                });
#pragma warning restore 612, 618
        }
    }
}
