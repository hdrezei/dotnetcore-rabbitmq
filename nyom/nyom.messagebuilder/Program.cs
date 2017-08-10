using System;

namespace nyom.messagebuilder
{
	public class Program
    {
	    public static void Main(String[] args)
	    {
		    MessageBuilder mb = new MessageBuilder();
			Guid id = new Guid(args[0]);

			mb.MontarMensaagens(id);
	    }
    }
}
