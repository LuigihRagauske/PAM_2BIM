using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class _20260601023450_AddJogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "TB_JOGADORES",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_JOGADORES",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_ESTADIOS",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "TB_ESTADIOS",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TB_JOGOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_ESTADIOS_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "TB_ESTADIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_SELECOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SELECOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_JOGOS_SELECOES",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: false),
                    Golsa = table.Column<int>(type: "int", nullable: false),
                    GlosProrrogacao = table.Column<int>(type: "int", nullable: false),
                    GolsaDecisaoPenaltis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS_SELECOES", x => new { x.JogoId, x.SelecaoId });
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_SELECOES_TB_JOGOS_JogoId",
                        column: x => x.JogoId,
                        principalTable: "TB_JOGOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_SELECOES_TB_SELECOES_SelecaoId",
                        column: x => x.SelecaoId,
                        principalTable: "TB_SELECOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TECNICOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    SelecaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TECNICOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TECNICOS_TB_SELECOES_SelecaoId",
                        column: x => x.SelecaoId,
                        principalTable: "TB_SELECOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGADORES_SelecaoId",
                table: "TB_JOGADORES",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_EstadioId",
                table: "TB_JOGOS",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_SELECOES_SelecaoId",
                table: "TB_JOGOS_SELECOES",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TECNICOS_SelecaoId",
                table: "TB_TECNICOS",
                column: "SelecaoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_JOGADORES_TB_SELECOES_SelecaoId",
                table: "TB_JOGADORES",
                column: "SelecaoId",
                principalTable: "TB_SELECOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_JOGADORES_TB_SELECOES_SelecaoId",
                table: "TB_JOGADORES");

            migrationBuilder.DropTable(
                name: "TB_JOGOS_SELECOES");

            migrationBuilder.DropTable(
                name: "TB_TECNICOS");

            migrationBuilder.DropTable(
                name: "TB_JOGOS");

            migrationBuilder.DropTable(
                name: "TB_SELECOES");

            migrationBuilder.DropIndex(
                name: "IX_TB_JOGADORES_SelecaoId",
                table: "TB_JOGADORES");

            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "TB_JOGADORES",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_JOGADORES",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_ESTADIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "TB_ESTADIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
