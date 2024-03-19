using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCurrentUserIdInCommitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentUserId",
                table: "CommitmentForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "CommitmentForms");
        }
    }
}
