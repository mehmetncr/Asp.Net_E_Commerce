using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilgi.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class resimbaslik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimBaslik",
                table: "Urunler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimBaslik",
                table: "Urunler");
        }
    }
}
