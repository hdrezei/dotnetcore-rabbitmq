using System;
using MongoDB.Bson.Serialization.Attributes;
using nyom.domain.core.MongoDb.Repository.Interface;

namespace nyom.domain.Message
{
	[BsonDiscriminator(Required = true)]
	[BsonKnownTypes(typeof(Message))]
	public class Message : IEntity<string>
	{
		[BsonId]
		public string Id { get; set; }
		public string TemplateId { get; set; }
		public string CampanhaId { get; set; }
		public string Mensagem { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataEntregaMensagens { get; set; }
		public Enum Status { get; set; }
	}
}
