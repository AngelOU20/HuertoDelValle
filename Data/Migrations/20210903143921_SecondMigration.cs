using Microsoft.EntityFrameworkCore.Migrations;

namespace HuertoDelValle.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataProducto_DataCategoria_CategoriaId",
                table: "DataProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataProducto",
                table: "DataProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataCategoria",
                table: "DataCategoria");

            migrationBuilder.DropColumn(
                name: "NomProducto",
                table: "DataProducto");

            migrationBuilder.DropColumn(
                name: "NomCategoria",
                table: "DataCategoria");

            migrationBuilder.RenameTable(
                name: "DataProducto",
                newName: "T_Producto");

            migrationBuilder.RenameTable(
                name: "DataCategoria",
                newName: "T_Categoria");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "T_Producto",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX_DataProducto_CategoriaId",
                table: "T_Producto",
                newName: "IX_T_Producto_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenProducto",
                table: "T_Producto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionProducto",
                table: "T_Producto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "T_Producto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreCategoria",
                table: "T_Categoria",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Producto",
                table: "T_Producto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Categoria",
                table: "T_Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Producto_T_Categoria_CategoriaId",
                table: "T_Producto",
                column: "CategoriaId",
                principalTable: "T_Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Producto_T_Categoria_CategoriaId",
                table: "T_Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Producto",
                table: "T_Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Categoria",
                table: "T_Categoria");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "T_Producto");

            migrationBuilder.DropColumn(
                name: "NombreCategoria",
                table: "T_Categoria");

            migrationBuilder.RenameTable(
                name: "T_Producto",
                newName: "DataProducto");

            migrationBuilder.RenameTable(
                name: "T_Categoria",
                newName: "DataCategoria");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "DataProducto",
                newName: "Cantidad");

            migrationBuilder.RenameIndex(
                name: "IX_T_Producto_CategoriaId",
                table: "DataProducto",
                newName: "IX_DataProducto_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenProducto",
                table: "DataProducto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionProducto",
                table: "DataProducto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "NomProducto",
                table: "DataProducto",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomCategoria",
                table: "DataCategoria",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataProducto",
                table: "DataProducto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataCategoria",
                table: "DataCategoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataProducto_DataCategoria_CategoriaId",
                table: "DataProducto",
                column: "CategoriaId",
                principalTable: "DataCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
