using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoAutenticacao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCamposExtras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailVerificado",
                table: "Usuario",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailVerificado",
                table: "Usuario");
        }
    }
}
