using System;

namespace nyom.queuebuilder
{
	public interface IEnfileirarMensagens
	{
		bool EnfileirarMensagensPush(Guid id);
	}
}