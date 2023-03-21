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
        return CreatedAtAction(nameof(Get), new { _id = product._id }, product);
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
            return await _mongoDBService.GetAsync();
    }

    [HttpPut("{productBarcode}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddToProduct(string _id, [FromBody] int productAmount, string productLocation, string productBarcode)
    {
        await _mongoDBService.AddToProductAsync(_id, productAmount, productLocation, productBarcode);
        return NoContent();
    }

    [HttpDelete("{productBarcode}")]
    public async Task<IActionResult> Delete(string productBarcode)
    {
        await _mongoDBService.DeleteAsync(productBarcode);
        return NoContent();
    }
    
}