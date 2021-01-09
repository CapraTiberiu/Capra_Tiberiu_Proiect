﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Capra_Tiberiu_Proiect.Migrations
{
    public partial class Categorii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TelefonCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TelefonCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelefonCategory_Telefon_TelefonID",
                        column: x => x.TelefonID,
                        principalTable: "Telefon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelefonCategory_CategoryID",
                table: "TelefonCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonCategory_TelefonID",
                table: "TelefonCategory",
                column: "TelefonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefonCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
