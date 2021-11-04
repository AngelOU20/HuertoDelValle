using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HuertoDelValle.Data.Migrations
{
    public partial class OMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEnvio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    tipoEnvioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEnvio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEnvio_T_TipoEnvio_tipoEnvioId",
                        column: x => x.tipoEnvioId,
                        principalTable: "T_TipoEnvio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataEnvio_tipoEnvioId",
                table: "DataEnvio",
                column: "tipoEnvioId");
        }
    }
}
