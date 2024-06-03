using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApi.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string? Title { get; set; }
        public string? Generos { get; set; }
        public string? Url { get; set; }
        public int Views { get; set; }
    }
}
