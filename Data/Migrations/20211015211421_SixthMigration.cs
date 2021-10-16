using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HuertoDelValle.Data.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Receta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreReceta = table.Column<string>(type: "text", nullable: false),
                    urlImagen = table.Column<string>(type: "text", nullable: false),
                    DescripcionReceta = table.Column<string>(type: "text", nullable: false),
                    Ingrediente = table.Column<string>(type: "text", nullable: false),
                    Preparacion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Receta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Reseña",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comentario = table.Column<string>(type: "text", nullable: false),
                    Calificacion = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecetaId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Reseña", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Reseña_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Reseña_T_Receta_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "T_Receta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Reseña_RecetaId",
                table: "T_Reseña",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Reseña_UserId1",
                table: "T_Reseña",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Reseña");

            migrationBuilder.DropTable(
                name: "T_Receta");
        }
    }
}
