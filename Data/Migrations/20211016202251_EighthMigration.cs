using Microsoft.EntityFrameworkCore.Migrations;

namespace HuertoDelValle.Data.Migrations
{
    public partial class EighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Reseña_AspNetUsers_UserId1",
                table: "T_Reseña");

            migrationBuilder.DropIndex(
                name: "IX_T_Reseña_UserId1",
                table: "T_Reseña");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "T_Reseña");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "T_Reseña",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "T_Reseña",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "T_Reseña",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Reseña_UserId1",
                table: "T_Reseña",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Reseña_AspNetUsers_UserId1",
                table: "T_Reseña",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
