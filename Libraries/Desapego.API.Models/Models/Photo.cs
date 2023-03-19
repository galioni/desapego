using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Desapego.API.Models;

public class Photo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string URL { get; set; } = null!;
}