using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    public async Task<IActionResult> Create(ProductRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(form);
        }

        var result = await _productService.CreateAsync(form);

        return result.StatusCode switch
        {
            200 => Ok(result),
            400 => BadRequest(result),
            409 => Conflict(result),
            _ => Problem(),
        };
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IResponseResult result = await _productService.GetAllAsync();
        return Ok(result);
    }
}
