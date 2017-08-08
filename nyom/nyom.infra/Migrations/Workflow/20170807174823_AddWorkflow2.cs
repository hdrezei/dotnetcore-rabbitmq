using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations.Workflow
{
    public partial class AddWorkflow2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Workflows",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Workflows",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
