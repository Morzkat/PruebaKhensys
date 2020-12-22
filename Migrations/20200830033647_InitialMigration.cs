using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaKhensys.Infrastructure.Persistence.Context.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcuseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcuseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ExcuseTypeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 8, 29, 23, 36, 46, 725, DateTimeKind.Local).AddTicks(8142))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ExcuseTypes_ExcuseTypeId",
                        column: x => x.ExcuseTypeId,
                        principalTable: "ExcuseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ExcuseTypeId",
                table: "Employees",
                column: "ExcuseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExcuseTypes");
        }
    }
}
