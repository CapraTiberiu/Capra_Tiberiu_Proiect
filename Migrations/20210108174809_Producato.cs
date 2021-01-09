using Microsoft.EntityFrameworkCore.Migrations;

namespace Capra_Tiberiu_Proiect.Migrations
{
    public partial class Producato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Telefon",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Telefon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Telefon");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Telefon",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");
        }
    }
}
