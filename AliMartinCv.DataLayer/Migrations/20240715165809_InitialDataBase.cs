using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vlogs");

            migrationBuilder.DropTable(
                name: "vlogGroups");

            migrationBuilder.CreateTable(
                name: "BlogGroups",
                columns: table => new
                {
                    BlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogGroupTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogGroupParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogGroups", x => x.BlogGroupId);
                    table.ForeignKey(
                        name: "FK_BlogGroups_BlogGroups_BlogGroupParentId",
                        column: x => x.BlogGroupParentId,
                        principalTable: "BlogGroups",
                        principalColumn: "BlogGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogThumbnail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlogPublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    BlogIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogGroups_BlogGroupId",
                        column: x => x.BlogGroupId,
                        principalTable: "BlogGroups",
                        principalColumn: "BlogGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogGroups_BlogSubGroupId",
                        column: x => x.BlogSubGroupId,
                        principalTable: "BlogGroups",
                        principalColumn: "BlogGroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogGroups_BlogGroupParentId",
                table: "BlogGroups",
                column: "BlogGroupParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogGroupId",
                table: "Blogs",
                column: "BlogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogSubGroupId",
                table: "Blogs",
                column: "BlogSubGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogGroups");

            migrationBuilder.CreateTable(
                name: "vlogGroups",
                columns: table => new
                {
                    VlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlogGroupParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VlogGroupTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
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
                    VlogGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlogSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    VlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VlogIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VlogPublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VlogShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogThumbnail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VlogTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
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
    }
}
