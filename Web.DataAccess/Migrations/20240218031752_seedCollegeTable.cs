using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedCollegeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "CollegeId", "CollegeName" },
                values: new object[,]
                {
                    { 1, "Information Technology" },
                    { 2, "Computer Science" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
