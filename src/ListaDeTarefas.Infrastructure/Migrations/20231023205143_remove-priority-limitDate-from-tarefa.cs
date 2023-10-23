using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeTarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeprioritylimitDatefromtarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitDate",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tarefas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LimitDate",
                table: "Tarefas",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Tarefas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
