using InventoryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace InventoryAPI.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Product> _productCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _productCollection = database.GetCollection<Product>(mongoDBSettings.Value.CollectionName);
        }

     public async Task<List<Product>> GetAsync()
        {
            return await _productCollection.Find(new BsonDocument()).ToListAsync();
        }

    public async Task CreateAsync(Product product) 
        {
            await _productCollection.InsertOneAsync(product);
            return;
        }

    public async Task AddToProductAsync(string id, int productAmount, string productLocation, string productBarcode) 
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("Id", id);
            UpdateDefinition<Product> update = Builders<Product>.Update
            .Set(p => p.productAmount, productAmount)
            .Set(p => p.productLocation, productLocation)
            .Set(p => p.productBarcode, productBarcode);
            await _productCollection.UpdateOneAsync(filter, update);
            return;
        }
    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("Id", id);
        await _productCollection.DeleteOneAsync(filter);
        return;
    }
}