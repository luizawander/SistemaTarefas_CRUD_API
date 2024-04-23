﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTarefas.Migrations
{
    /// <inheritdoc />
    public partial class VinculoTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioID",
                table: "Tarefa",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioID",
                table: "Tarefa",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioID",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_UsuarioID",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Tarefa");
        }
    }
}
