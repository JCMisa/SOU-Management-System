using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserInCommitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "CommitmentForms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentForms_IdentityUserId",
                table: "CommitmentForms",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentForms_AspNetUsers_IdentityUserId",
                table: "CommitmentForms",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentForms_AspNetUsers_IdentityUserId",
                table: "CommitmentForms");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentForms_IdentityUserId",
                table: "CommitmentForms");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "CommitmentForms");
        }
    }
}
