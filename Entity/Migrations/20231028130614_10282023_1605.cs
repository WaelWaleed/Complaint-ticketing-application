using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class _10282023_1605 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Complaint",
                newName: "UserNumber");

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Complaint",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Complaint",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Complaint",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Complaint");

            migrationBuilder.RenameColumn(
                name: "UserNumber",
                table: "Complaint",
                newName: "Name");
        }
    }
}
