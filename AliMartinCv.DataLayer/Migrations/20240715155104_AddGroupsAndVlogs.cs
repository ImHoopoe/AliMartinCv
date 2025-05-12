using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupsAndVlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vlogGroups",
                columns: table => new
                {
                    VlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlogGroupTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogGroupParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vlogGroups", x => x.VlogGroupId);
                    table.ForeignKey(
                        name: "FK_vlogGroups_vlogGroups_VlogGroupParentId",
                        column: x => x.VlogGroupParentId,
                        principalTable: "vlogGroups",
                        principalColumn: "VlogGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Vlogs",
                columns: table => new
                {
                    VlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlogTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogThumbnail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogPublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    VlogIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlogSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlogs", x => x.VlogId);
                    table.ForeignKey(
                        name: "FK_Vlogs_vlogGroups_VlogGroupId",
                        column: x => x.VlogGroupId,
                        principalTable: "vlogGroups",
                        principalColumn: "VlogGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vlogs_vlogGroups_VlogSubGroupId",
                        column: x => x.VlogSubGroupId,
                        principalTable: "vlogGroups",
                        principalColumn: "VlogGroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_vlogGroups_VlogGroupParentId",
                table: "vlogGroups",
                column: "VlogGroupParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlogs_VlogGroupId",
                table: "Vlogs",
                column: "VlogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlogs_VlogSubGroupId",
                table: "Vlogs",
                column: "VlogSubGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vlogs");

            migrationBuilder.DropTable(
                name: "vlogGroups");
        }
    }
}
