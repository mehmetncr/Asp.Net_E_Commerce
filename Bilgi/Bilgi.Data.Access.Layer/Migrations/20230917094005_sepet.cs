using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilgi.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class sepet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sepettler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    ToplamAdet = table.Column<int>(type: "int", nullable: false),
                    ToplamnTutar = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepettler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SepetDetaylari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepetId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetDetaylari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SepetDetaylari_Sepettler_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Sepettler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SepetDetaylari_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SepetDetaylari_SepetId",
                table: "SepetDetaylari",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_SepetDetaylari_UrunId",
                table: "SepetDetaylari",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SepetDetaylari");

            migrationBuilder.DropTable(
                name: "Sepettler");
        }
    }
}
