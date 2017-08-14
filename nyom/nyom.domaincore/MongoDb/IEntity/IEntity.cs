using System;

namespace nyom.domain.core.MongoDb.IEntity
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

	public interface IEntityCommom : IEntity<ObjectId>
	{
		string TemplateId { get; set; }
		string CampanhaId { get; set; }
		string Mensagem { get; set; }
		DateTime DataCriacao { get; set; }
		DateTime DataEntregaMensagens { get; set; }
		Enum Status { get; set; }
	}
}