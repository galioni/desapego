using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Desapego.API.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool RecordStatus { get; set; }

    public Photo? Photos { get; set; }
}