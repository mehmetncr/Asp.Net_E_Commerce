using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilgi.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class isimdeg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SatisDurumu",
                table: "Urunler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SatisDurumu",
                table: "Urunler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
