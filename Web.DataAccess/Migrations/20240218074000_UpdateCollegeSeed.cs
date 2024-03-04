using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCollegeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 1,
                column: "CollegeName",
                value: "Teacher Education");

            migrationBuilder.UpdateData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 2,
                column: "CollegeName",
                value: "Computer Studies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 1,
                column: "CollegeName",
                value: "Information Technology");

            migrationBuilder.UpdateData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: 2,
                column: "CollegeName",
                value: "Computer Science");
        }
    }
}
