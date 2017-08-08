using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations.Workflow
{
    public partial class AddWorkflow4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Campanhas",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "Publico",
                table: "Campanhas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publico",
                table: "Campanhas");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Campanhas",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
