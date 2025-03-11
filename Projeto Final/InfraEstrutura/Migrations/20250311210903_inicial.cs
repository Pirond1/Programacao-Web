using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    dataNascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    salario = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    dataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    idArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Area",
                        column: x => x.idArea,
                        principalTable: "Area",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Serviço",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    valorHora = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    idArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviço", x => x.id);
                    table.ForeignKey(
                        name: "FK_Serviço_Area",
                        column: x => x.idArea,
                        principalTable: "Area",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horas = table.Column<int>(type: "int", nullable: false),
                    dataConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idServico = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idFuncionario = table.Column<int>(type: "int", nullable: false),
                    idPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consulta_Cliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Funcionario",
                        column: x => x.idFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Pagamento",
                        column: x => x.idPagamento,
                        principalTable: "Pagamento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Serviço",
                        column: x => x.idServico,
                        principalTable: "Serviço",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idCliente",
                table: "Consulta",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idFuncionario",
                table: "Consulta",
                column: "idFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idPagamento",
                table: "Consulta",
                column: "idPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idServico",
                table: "Consulta",
                column: "idServico");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_idArea",
                table: "Funcionario",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_Serviço_idArea",
                table: "Serviço",
                column: "idArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Serviço");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
