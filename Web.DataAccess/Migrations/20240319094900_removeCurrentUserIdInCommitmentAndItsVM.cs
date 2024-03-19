using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeCurrentUserIdInCommitmentAndItsVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "CommitmentForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentUserId",
                table: "CommitmentForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
