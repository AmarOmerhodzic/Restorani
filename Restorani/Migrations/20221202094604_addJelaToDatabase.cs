using Microsoft.EntityFrameworkCore.Migrations;

namespace Restorani.Migrations
{
    public partial class addJelaToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<decimal>(type: "smallmoney", nullable: false),
                    RestoranId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jela_Restorani_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Restorani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jela_RestoranId",
                table: "Jela",
                column: "RestoranId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jela");
        }
    }
}
