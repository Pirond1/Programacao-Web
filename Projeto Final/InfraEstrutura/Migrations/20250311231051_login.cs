using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idFuncionario = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Login_idFuncionario",
                table: "Login",
                column: "idFuncionario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
