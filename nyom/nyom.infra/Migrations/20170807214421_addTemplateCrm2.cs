using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations
{
    public partial class addTemplateCrm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Templates",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "Templates",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TokenPush",
                table: "Notifications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThreadName",
                table: "Notifications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRobo",
                table: "Notifications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contexto",
                table: "Notifications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoRobo",
                table: "Configurations",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "Templates");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Templates",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TokenPush",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ThreadName",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRobo",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Contexto",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TipoRobo",
                table: "Configurations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    ConfigurationId = table.Column<Guid>(nullable: false),
                    AutoScaleChannels = table.Column<bool>(nullable: false),
                    Channels = table.Column<int>(nullable: false),
                    ConexaoAtiva = table.Column<bool>(nullable: false),
                    ConnectionTimeout = table.Column<int>(nullable: false),
                    FeedbackIntervalMinutes = table.Column<int>(nullable: false),
                    HoraFim = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    IdMaquina = table.Column<int>(nullable: false),
                    IdleTimeOut = table.Column<int>(nullable: false),
                    MaxAutoScaleChannels = table.Column<int>(nullable: false),
                    MaxConnectionAttempts = table.Column<int>(nullable: false),
                    MaxNotificationRequeues = table.Column<int>(nullable: false),
                    MillisecondsToWaitBeforeMessageDeclaredSuccess = table.Column<int>(nullable: false),
                    MinAvgTimeToScaleChannels = table.Column<int>(nullable: false),
                    NotificationSendTimeout = table.Column<int>(nullable: false),
                    QuantidadeEnvio = table.Column<int>(nullable: false),
                    TempoProcessamento = table.Column<int>(nullable: false),
                    TipoRobo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UsaSandBox = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.ConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(nullable: false),
                    Cadastrado = table.Column<int>(nullable: false),
                    CodigoAplicativo = table.Column<int>(nullable: false),
                    CodigoNotificacao = table.Column<int>(nullable: false),
                    CodigoTemplate = table.Column<int>(nullable: false),
                    Contexto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdServidor = table.Column<int>(nullable: false),
                    MaxRegistros = table.Column<int>(nullable: false),
                    NomeRobo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Plataforma = table.Column<int>(nullable: false),
                    ThreadName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TokenPush = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });
        }
    }
}
