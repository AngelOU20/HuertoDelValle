using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HuertoDelValle.Data.Migrations
{
    public partial class NinthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_TipoEnvio",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lugar = table.Column<string>(type: "text", nullable: false),
                    precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TipoEnvio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DataEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoEnvioId = table.Column<int>(type: "integer", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechapedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    subtotal = table.Column<double>(type: "double precision", nullable: false),
                    codcliente = table.Column<string>(type: "text", nullable: true),
                    envio = table.Column<int>(type: "integer", nullable: true),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_pedido_estados_estado",
                        column: x => x.estado,
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pedido_T_TipoEnvio_envio",
                        column: x => x.envio,
                        principalTable: "T_TipoEnvio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataEnvio_tipoEnvioId",
                table: "DataEnvio",
                column: "tipoEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_envio",
                table: "pedido",
                column: "envio");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_estado",
                table: "pedido",
                column: "estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEnvio");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "T_TipoEnvio");
        }
    }
}
