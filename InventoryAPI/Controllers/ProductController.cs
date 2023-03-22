using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers;

[Controller]
[Route("api/[Controller]")]
public class ProductController : Controller
{
    private readonly MongoDBService _mongoDBService;

    Product updateProduct = new Product();

    public ProductController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;

    }

    //  Crud functions

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product) 
    {
        await _mongoDBService.CreateAsync(product);
        return CreatedAtAction(nameof(Get), new { _id = product._id }, product);
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
            return await _mongoDBService.GetAsync();
    }

    [HttpPut("{_id}")]
    public async Task<IActionResult> AddToProduct(string _id, [FromBody] Product updateProduct)
    {
        await _mongoDBService.AddToProductAsync(_id, updateProduct);
        return NoContent();
    }

    [HttpDelete("{_id}")]
    public async Task<IActionResult> Delete(string _id)
    {
        await _mongoDBService.DeleteAsync(_id);
        return NoContent();
    }
    
}