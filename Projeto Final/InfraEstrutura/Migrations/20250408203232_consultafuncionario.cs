using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class consultafuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Funcionario",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_idFuncionario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "idFuncionario",
                table: "Consulta");

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "valorTotal",
                table: "Consulta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultafuncionarios");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "usuario",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "valorTotal",
                table: "Consulta");

            migrationBuilder.AddColumn<int>(
                name: "idFuncionario",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFuncionario = table.Column<int>(type: "int", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.id);
                    table.ForeignKey(
                        name: "FK_Login_Funcionario",
                        column: x => x.idFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idFuncionario",
                table: "Consulta",
                column: "idFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Login_idFuncionario",
                table: "Login",
                column: "idFuncionario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Funcionario",
                table: "Consulta",
                column: "idFuncionario",
                principalTable: "Funcionario",
                principalColumn: "id");
        }
    }
}
