using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastrosFornecedores.Migrations
{
    public partial class AlteracaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraCadastro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "PessoaFisica",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Fornecedores",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Fornecedores",
                newName: "RG");

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraCadastro",
                table: "Fornecedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PessoaFisica",
                table: "Fornecedores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
