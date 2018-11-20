using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkMigrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wage = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    SlaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meow_Meow_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Meow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meow_Persons_SlaveId",
                        column: x => x.SlaveId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meow_ParentId",
                table: "Meow",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Meow_SlaveId",
                table: "Meow",
                column: "SlaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meow");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
