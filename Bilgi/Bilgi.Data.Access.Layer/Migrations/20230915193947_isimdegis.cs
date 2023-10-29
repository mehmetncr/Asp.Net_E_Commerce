using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilgi.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class isimdegis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KirtasiyeOzellikleri_Urunler_UrunId",
                table: "KirtasiyeOzellikleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KirtasiyeOzellikleri",
                table: "KirtasiyeOzellikleri");

            migrationBuilder.RenameTable(
                name: "KirtasiyeOzellikleri",
                newName: "Ozellikler");

            migrationBuilder.RenameIndex(
                name: "IX_KirtasiyeOzellikleri_UrunId",
                table: "Ozellikler",
                newName: "IX_Ozellikler_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ozellikler",
                table: "Ozellikler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ozellikler_Urunler_UrunId",
                table: "Ozellikler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ozellikler_Urunler_UrunId",
                table: "Ozellikler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ozellikler",
                table: "Ozellikler");

            migrationBuilder.RenameTable(
                name: "Ozellikler",
                newName: "KirtasiyeOzellikleri");

            migrationBuilder.RenameIndex(
                name: "IX_Ozellikler_UrunId",
                table: "KirtasiyeOzellikleri",
                newName: "IX_KirtasiyeOzellikleri_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KirtasiyeOzellikleri",
                table: "KirtasiyeOzellikleri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KirtasiyeOzellikleri_Urunler_UrunId",
                table: "KirtasiyeOzellikleri",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
