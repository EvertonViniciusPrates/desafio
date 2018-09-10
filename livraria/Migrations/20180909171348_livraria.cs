using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace livraria.Migrations
{
    public partial class livraria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "livraria");

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "livraria",
                columns: table => new
                {
                    co_cliente = table.Column<Guid>(nullable: false),
                    nm_cliente = table.Column<string>(nullable: true),
                    cpf_cliente = table.Column<string>(nullable: true),
                    dtn_cliente = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.co_cliente);
                });

            migrationBuilder.CreateTable(
                name: "livro",
                schema: "livraria",
                columns: table => new
                {
                    co_livro = table.Column<Guid>(nullable: false),
                    nm_livro = table.Column<string>(nullable: true),
                    ds_livro = table.Column<string>(nullable: true),
                    au_livro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.co_livro);
                });

            migrationBuilder.CreateTable(
                name: "aluguel",
                schema: "livraria",
                columns: table => new
                {
                    co_aluguel = table.Column<Guid>(nullable: false),
                    dr_aluguel = table.Column<DateTime>(nullable: false),
                    de_aluguel = table.Column<DateTime>(nullable: false),
                    st_aluguel = table.Column<bool>(nullable: false),
                    co_cliente = table.Column<Guid>(nullable: false),
                    co_livro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluguel", x => x.co_aluguel);
                    table.ForeignKey(
                        name: "FK_aluguel_cliente_co_cliente",
                        column: x => x.co_cliente,
                        principalSchema: "livraria",
                        principalTable: "cliente",
                        principalColumn: "co_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aluguel_livro_co_livro",
                        column: x => x.co_livro,
                        principalSchema: "livraria",
                        principalTable: "livro",
                        principalColumn: "co_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluguel_co_cliente",
                schema: "livraria",
                table: "aluguel",
                column: "co_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_aluguel_co_livro",
                schema: "livraria",
                table: "aluguel",
                column: "co_livro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluguel",
                schema: "livraria");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "livraria");

            migrationBuilder.DropTable(
                name: "livro",
                schema: "livraria");
        }
    }
}
