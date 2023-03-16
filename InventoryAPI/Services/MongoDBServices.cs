using InventoryAPI.Models;
using Microsoft.Extentions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace InventoryAPI.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Product> _productCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(MongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(MongoDBSettings.Value.DatabaseName)
        _productCollection = database.GetCollection<Product>(mongoDBSettings.Value.CollectionName);
    }
}