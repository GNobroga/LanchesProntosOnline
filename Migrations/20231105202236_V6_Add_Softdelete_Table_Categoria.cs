using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaLanches.Migrations
{
    /// <inheritdoc />
    public partial class V6_Add_Softdelete_Table_Categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Categorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Categorias");
        }
    }
}
