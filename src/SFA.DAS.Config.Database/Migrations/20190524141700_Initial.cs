using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFA.DAS.Config.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantObjects",
                columns: table => new
                {
                    TenantObjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantObjects", x => x.TenantObjectId);
                });

            migrationBuilder.CreateTable(
                name: "TenantGroups",
                columns: table => new
                {
                    TenantGroupId = table.Column<Guid>(nullable: false),
                    TenantObjectId = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantGroups", x => x.TenantGroupId);
                    table.ForeignKey(
                        name: "FK_TenantGroups_TenantObjects_TenantObjectId",
                        column: x => x.TenantObjectId,
                        principalTable: "TenantObjects",
                        principalColumn: "TenantObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantUsers",
                columns: table => new
                {
                    TenantUserId = table.Column<Guid>(nullable: false),
                    TenantObjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUsers", x => x.TenantUserId);
                    table.ForeignKey(
                        name: "FK_TenantUsers_TenantObjects_TenantObjectId",
                        column: x => x.TenantObjectId,
                        principalTable: "TenantObjects",
                        principalColumn: "TenantObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantGroupMembership",
                columns: table => new
                {
                    TenantGroupId = table.Column<Guid>(nullable: false),
                    TenantObjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantGroupMembership", x => new { x.TenantGroupId, x.TenantObjectId });
                    table.ForeignKey(
                        name: "FK_TenantGroupMembership_TenantGroups_TenantGroupId",
                        column: x => x.TenantGroupId,
                        principalTable: "TenantGroups",
                        principalColumn: "TenantGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TenantGroupMembership_TenantObjects_TenantObjectId",
                        column: x => x.TenantObjectId,
                        principalTable: "TenantObjects",
                        principalColumn: "TenantObjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantGroupMembership_TenantObjectId",
                table: "TenantGroupMembership",
                column: "TenantObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantGroups_TenantObjectId",
                table: "TenantGroups",
                column: "TenantObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUsers_TenantObjectId",
                table: "TenantUsers",
                column: "TenantObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantGroupMembership");

            migrationBuilder.DropTable(
                name: "TenantUsers");

            migrationBuilder.DropTable(
                name: "TenantGroups");

            migrationBuilder.DropTable(
                name: "TenantObjects");
        }
    }
}
