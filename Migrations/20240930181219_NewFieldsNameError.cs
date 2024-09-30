using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchServer.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsNameError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "applicationDate",
                table: "Jobs",
                newName: "ApplicationDate");

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "Jobs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "ApplicationDate",
                table: "Jobs",
                newName: "applicationDate");
        }
    }
}
