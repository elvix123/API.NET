using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TodoApi.Models
{
    public class Visualizacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string IdUsuario { get; set; }  = default!;// ID del usuario
        public string IdMovie { get; set; } = default!; // ID de la película
        public TimeSpan TimeVisualizacion { get; set; }
        public bool Like { get; set; }
    }
}
