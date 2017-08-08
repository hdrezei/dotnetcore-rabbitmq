using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations.Workflow
{
    public partial class AddWorkflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    CampanhaId = table.Column<Guid>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.CampanhaId);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    WorkflowId = table.Column<Guid>(nullable: false),
                    CampanhaId = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.WorkflowId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Workflows");
        }
    }
}
