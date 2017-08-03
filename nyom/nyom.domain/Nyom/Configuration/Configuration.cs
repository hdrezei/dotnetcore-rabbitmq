using System;

namespace nyom.domain.Nyom.Configuration
{
    public class Configuration
    {
	    public Configuration()
	    {
		    ConfigurationId = Guid.NewGuid();
	    }

		public Guid ConfigurationId { get; set; }
	    public int TempoProcessamento { get; set; }
	    public int QuantidadeEnvio { get; set; }
		public bool ConexaoAtiva { get; set; }
	    public int IdMaquina { get; set; }
	    public bool UsaSandBox { get; set; }
	    public bool AutoScaleChannels { get; set; }
	    public int MaxAutoScaleChannels { get; set; }
	    public int MinAvgTimeToScaleChannels { get; set; }
	    public int Channels { get; set; }
	    public int MaxNotificationRequeues { get; set; }
	    public int NotificationSendTimeout { get; set; }
	    public int IdleTimeOut { get; set; }
	    public int ConnectionTimeout { get; set; }
		public int MaxConnectionAttempts { get; set; }
	    public int MillisecondsToWaitBeforeMessageDeclaredSuccess { get; set; }
	    public int FeedbackIntervalMinutes { get; set; }
	    public string TipoRobo { get; set; }
	    public DateTime HoraInicio { get; set; }
		public DateTime HoraFim { get; set; }
	}
}
