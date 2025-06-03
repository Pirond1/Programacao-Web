using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultafuncionarios");

            migrationBuilder.AddColumn<int>(
                name: "idFuncionario",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idFuncionario",
                table: "Consulta",
                column: "idFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Funcionario",
                table: "Consulta",
                column: "idFuncionario",
                principalTable: "Funcionario",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Funcionario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_idFuncionario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "idFuncionario",
                table: "Consulta");

            migrationBuilder.CreateTable(
                name: "consultafuncionarios",
                columns: table => new
                {
                    consultaId = table.Column<int>(type: "int", nullable: false),
                    funcionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultafuncionarios", x => new { x.consultaId, x.funcionarioId });
                    table.ForeignKey(
                        name: "FK_ConsultaFuncionario_Consulta",
                        column: x => x.consultaId,
                        principalTable: "Consulta",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ConsultaFuncionario_Funcionario",
                        column: x => x.funcionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultafuncionarios_funcionarioId",
                table: "consultafuncionarios",
                column: "funcionarioId");
        }
    }
}
