using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDBREOS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    GId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    DependsOn = table.Column<string>(nullable: true),
                    Duplicates = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Reported = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Blocks = table.Column<string>(nullable: true),
                    Commit_ID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Project_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.GId);
                    table.ForeignKey(
                        name: "FK_Project_Projects_Project_Id",
                        column: x => x.Project_Id,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAD",
                columns: table => new
                {
                    GId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Project_Id = table.Column<Guid>(nullable: true),
                    ProjectGId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAD", x => x.GId);
                    table.ForeignKey(
                        name: "FK_ProjectAD_Project_ProjectGId",
                        column: x => x.ProjectGId,
                        principalTable: "Project",
                        principalColumn: "GId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_Project_Id",
                table: "Project",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAD_ProjectGId",
                table: "ProjectAD",
                column: "ProjectGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAD");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
