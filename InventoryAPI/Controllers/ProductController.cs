using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers;

public class ProductController : Controller
{
    private readonly MongoDBService _mongoDBService;
    public ProductController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;

    }
    public async Task<List<Product>> Get()
        {
            return await _mongoDBService.GetAsync();
        }
    // Create CRUD Functions
}