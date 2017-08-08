using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nyom.infra.Migrations
{
    public partial class AddCrm : Migration
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
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
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

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
