using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    public partial class UpdatePessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades");

            migrationBuilder.RenameTable(
                name: "Cidades",
                newName: "Cidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "Cidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades",
                column: "Id");
        }
    }
}
