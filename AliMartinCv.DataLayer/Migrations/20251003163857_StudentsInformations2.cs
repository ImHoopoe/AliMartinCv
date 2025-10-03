using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class StudentsInformations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompeleted",
                table: "StudentsInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompeleted",
                table: "StudentsInformations");
        }
    }
}
