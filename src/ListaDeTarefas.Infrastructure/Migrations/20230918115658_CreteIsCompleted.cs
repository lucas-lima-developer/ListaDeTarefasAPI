using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeTarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreteIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Tarefas");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tarefas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tarefas");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateDeleted",
                table: "Tarefas",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
