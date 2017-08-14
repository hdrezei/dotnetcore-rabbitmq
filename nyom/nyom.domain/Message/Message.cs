using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nyom.domain.Message
{
	
	[BsonDiscriminator(Required = true)]
	[BsonKnownTypes(typeof(Message))]
	public class Message : IMessage
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string TemplateId { get; set; }
		public string CampanhaId { get; set; }
		public string Mensagem { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataEntregaMensagens { get; set; }
		public Enum Status { get; set; }
		
	}
}
