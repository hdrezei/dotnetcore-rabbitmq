using System;
using MongoDB.Bson.Serialization.Attributes;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.Message
{
	public class Message : IEntity
	{
		public Guid Id { get; set; }
		public string TemplateId { get; set; }
		public string CampanhaId { get; set; }
		public string Mensagem { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataEntregaMensagens { get; set; }
		public Enum Status { get; set; }
	}
}
