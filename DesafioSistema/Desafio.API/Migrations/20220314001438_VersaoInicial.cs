using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.API.Migrations
{
    public partial class VersaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    senha = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    telefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    end_logradouro = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    end_numero = table.Column<int>(type: "integer", nullable: false),
                    end_complemento = table.Column<string>(type: "text", nullable: true),
                    end_bairro = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    end_cidade = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    end_uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    dt_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_CPF",
                table: "usuarios",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
