using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddFullNameToStudentForParentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentFullName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentFullName",
                table: "Parents");
        }
    }
}
