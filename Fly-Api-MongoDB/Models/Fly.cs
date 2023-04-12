using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace fly_API.Models
{
    public class Fly
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }


        [BsonElement("origen")]
        public string origen { get; set; } = string.Empty;


        [BsonElement("destino")]
        public string destino { get; set; } = string.Empty;


        [BsonElement("pasajeros")]
        public int pasajeros { get; set; }

        [BsonElement("ida")]
        public DateTime ida { get; set; } = new DateTime();


        [BsonElement("vuelta")]
        public DateTime vuelta { get; set; } = new DateTime();
    }
}