using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HuertoDelValle.Data.Migrations
{
    public partial class TenthMigration : Migration
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
                name: "pedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechapedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "T_pedido_producto",
                columns: table => new
                {
                    numPedido = table.Column<int>(type: "integer", nullable: false),
                    numProducto = table.Column<int>(type: "integer", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_pedido_producto", x => new { x.numPedido, x.numProducto });
                    table.ForeignKey(
                        name: "FK_T_pedido_producto_pedido_numPedido",
                        column: x => x.numPedido,
                        principalTable: "pedido",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_pedido_producto_T_Producto_numProducto",
                        column: x => x.numProducto,
                        principalTable: "T_Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_pedido_envio",
                table: "pedido",
                column: "envio");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_estado",
                table: "pedido",
                column: "estado");

            migrationBuilder.CreateIndex(
                name: "IX_T_pedido_producto_numProducto",
                table: "T_pedido_producto",
                column: "numProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEnvio");

            migrationBuilder.DropTable(
                name: "T_pedido_producto");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "T_TipoEnvio");
        }
    }
}
