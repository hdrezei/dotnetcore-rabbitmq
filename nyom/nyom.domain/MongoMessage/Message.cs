﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using nyom.domain.core.MongoDb.Message.Interface;

namespace nyom.domain.MongoMessage
{
	public class Message : IEntity
	{ 

	    [BsonRepresentation(BsonType.ObjectId)]
	    public string Id { get; set; }
		public string TemplateId { get; set; }
		public string CampanhaId { get; set; }
		public string Mensagem { get; set; }
		public int Status { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataEntregaMensagens { get; set; }
	}
}
