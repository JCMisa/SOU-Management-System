using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCollegeSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "CollegeId", "CollegeName" },
                values: new object[,]
                {
                    { 1, "COLLEGE OF ARTS AND SCIENCES (CAS)" },
                    { 2, "COLLEGE OF BUSINESS, ADMINISTRATION AND ACCOUNTANCY (CBAA)" }
                });
        }
    }
}
