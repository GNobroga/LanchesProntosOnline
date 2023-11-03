using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VendaLanches.Migrations
{
    /// <inheritdoc />
    public partial class V6_Create_Table_Entrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarrinhoId",
                table: "Pedidos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "EntregaId",
                table: "Pedidos",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Lanches",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumbnailUrl",
                table: "Lanches",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    EntregaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PedidoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    QntPedidos = table.Column<int>(type: "integer", nullable: false),
                    PedidoEnviado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PedidoEntregueEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.EntregaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EntregaId",
                table: "Pedidos",
                column: "EntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Entregas_EntregaId",
                table: "Pedidos",
                column: "EntregaId",
                principalTable: "Entregas",
                principalColumn: "EntregaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregas_EntregaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EntregaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EntregaId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "CarrinhoId",
                table: "Pedidos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Lanches",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumbnailUrl",
                table: "Lanches",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
