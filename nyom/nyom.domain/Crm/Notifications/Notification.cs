using System;

namespace nyom.domain.Crm.Notifications
{
	public class Notification 
	{
	    public Notification()
	    {
		    NotificationId = Guid.NewGuid();
	    }
		public Guid NotificationId { get; set; } 
	    public int MaxRegistros { get; set; }
		public int Plataforma { get; set; }
	    public int CodigoAplicativo { get; set; }
	    public string ThreadName { get; set; }
	    public int IdServidor { get; set; }
		public int Cadastrado { get; set; }
		public string NomeRobo { get; set; }
	    public int CodigoNotificacao { get; set; }
	    public int CodigoTemplate { get; set; }
		public string TokenPush { get; set; }
	    public string Contexto { get; set; }

		
	}
}
