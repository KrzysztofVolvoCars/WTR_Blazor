using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WTR_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PowerBI_URL",
                table: "NewProjects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectPhaseId",
                table: "NewProjects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewProjects_ProjectPhaseId",
                table: "NewProjects",
                column: "ProjectPhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewProjects_ProjectPhases_ProjectPhaseId",
                table: "NewProjects",
                column: "ProjectPhaseId",
                principalTable: "ProjectPhases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewProjects_ProjectPhases_ProjectPhaseId",
                table: "NewProjects");

            migrationBuilder.DropIndex(
                name: "IX_NewProjects_ProjectPhaseId",
                table: "NewProjects");

            migrationBuilder.DropColumn(
                name: "PowerBI_URL",
                table: "NewProjects");

            migrationBuilder.DropColumn(
                name: "ProjectPhaseId",
                table: "NewProjects");
        }
    }
}
