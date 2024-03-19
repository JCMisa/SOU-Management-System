using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addNewFieldsToTrackUserAndCreationDateInCommitmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CommitmentForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommitmentForms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentForms_UserId",
                table: "CommitmentForms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentForms_AspNetUsers_UserId",
                table: "CommitmentForms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentForms_AspNetUsers_UserId",
                table: "CommitmentForms");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentForms_UserId",
                table: "CommitmentForms");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CommitmentForms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommitmentForms");
        }
    }
}
