using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeTarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class usertarefarelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Tarefas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UserId",
                table: "Tarefas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Users_UserId",
                table: "Tarefas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Users_UserId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UserId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tarefas");
        }
    }
}
