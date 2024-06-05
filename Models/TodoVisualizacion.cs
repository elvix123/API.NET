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

        public string IdUsuario { get; set; }  = default!; // ID del usuario
        public string IdMovie { get; set; } = default!; // ID de la película
        public TimeSpan TimeVisualizacion { get; set; }
        public bool Like { get; set; } // True or False si dio like o no
        public int Rating { get; set; } // Calificación de la película
        public string? Comentario { get; set; } // Comentario del usuario
        public bool Compartir { get; set; } // Si el usuario compartió la película
        public bool Repetir { get; set; } // Si el usuario repitió la visualización
        public int Sumatoria { get; set; } // Sumatoria de likes o visualizaciones
        public DateTime Fecha { get; set; } = DateTime.UtcNow; // Fecha de la visualización
        public DateTime FechaVisualizacion { get; set; } = DateTime.UtcNow; // Fecha específica de visualización
    }
}
