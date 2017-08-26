namespace nyom.messagebuilder
{
	public class Builder
	{
		private readonly IMensagens _mensagens;

		public Builder(IMensagens mensagens)
		{
			_mensagens = mensagens;
		}

		public void Start()
		{
			//_mensagens.MontarMensagens(Environment.GetEnvironmentVariable("CAMPANHA"));
			_mensagens.MontarMensagens("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060");
		}
	}
}