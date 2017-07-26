using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
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
                    table.PrimaryKey("PK_Configurations", x => x.ConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
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
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
