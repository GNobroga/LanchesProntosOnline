using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaLanches.Migrations
{
    /// <inheritdoc />
    public partial class V2_Populate_Table_Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("INSERT INTO \"Categorias\" (\"CategoriaNome\", \"CategoriaDescricao\") " +
                "VALUES('Normal','Lanche feito com ingredientes normais')");

            migrationBuilder.Sql("INSERT INTO \"Categorias\" (\"CategoriaNome\", \"CategoriaDescricao\") " +
                "VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
