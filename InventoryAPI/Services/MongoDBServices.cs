using InventoryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace InventoryAPI.Services;

public class MongoDBService
{

    Product updateProduct = new Product();
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

    public async Task AddToProductAsync(string _id, Product updateProduct) 
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("_id", _id);
            UpdateDefinition<Product> update = Builders<Product>.Update
                .Set(p => p.productAmount, updateProduct.productAmount)
                .Set(p => p.productLocation, updateProduct.productLocation)
                .Set(p => p.productBarcode, updateProduct.productBarcode);
            await _productCollection.UpdateOneAsync(filter, update);
            return;
        }
    public async Task DeleteAsync(string _id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("_id", _id);
        await _productCollection.DeleteOneAsync(filter);
        return;
    }
}