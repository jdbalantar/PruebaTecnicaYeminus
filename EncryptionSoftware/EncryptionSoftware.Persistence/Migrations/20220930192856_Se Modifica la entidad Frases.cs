using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncryptionSoftware.Persistence.Migrations
{
    public partial class SeModificalaentidadFrases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clave",
                table: "Frases",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clave",
                table: "Frases");
        }
    }
}
