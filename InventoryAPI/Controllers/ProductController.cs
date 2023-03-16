using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers;

public class ProductController : Controller
{
    private readonly MongoDBService _mongoDBService;
    public PlaylistController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    // Create CRUD Functions
}