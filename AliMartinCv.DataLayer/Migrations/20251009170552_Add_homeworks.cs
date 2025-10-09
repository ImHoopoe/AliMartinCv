using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Add_homeworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeWork",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    HomeWorkTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HomeWorkDescriptions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    HomeWorkType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWork", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK_HomeWork_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentHomeWork",
                columns: table => new
                {
                    StudentHomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeWorkId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHomeWork", x => x.StudentHomeWorkId);
                    table.ForeignKey(
                        name: "FK_StudentHomeWork_HomeWork_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWork",
                        principalColumn: "HomeWorkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentHomeWork_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeWork_ClassId",
                table: "HomeWork",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHomeWork_HomeWorkId_StudentId",
                table: "StudentHomeWork",
                columns: new[] { "HomeWorkId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentHomeWork_StudentId",
                table: "StudentHomeWork",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHomeWork");

            migrationBuilder.DropTable(
                name: "HomeWork");
        }
    }
}
