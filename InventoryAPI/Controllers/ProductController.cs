using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers;

[Controller]
[Route("api/[Controller]")]
public class ProductController : Controller
{
    private readonly MongoDBService _mongoDBService;
    public ProductController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;

    }

    //  Crud functions

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product) 
    {
        await _mongoDBService.CreateAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
            return await _mongoDBService.GetAsync();
    }

     [HttpPut("{id}")]
    public async Task<IActionResult> AddToProduct(string id, [FromBody] int productAmount, string productLocation, string productBarcode)
    {
        await _mongoDBService.AddToProductAsync(id, productAmount, productLocation, productBarcode);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }
    
}