using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class IsActivated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Students",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Students");
        }
    }
}
