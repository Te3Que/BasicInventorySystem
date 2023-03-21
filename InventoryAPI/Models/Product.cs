using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace InventoryAPI.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    public string productName { get; set; }
    public int productAmount { get; set; }
    public string productLocation { get; set; }
    public string productBarcode { get; set; }

}