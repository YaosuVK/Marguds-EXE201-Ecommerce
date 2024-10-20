using BussinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Product;
using Service.RequestAndResponse.Response.Product;

namespace Marguds_EXE201_Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpGet]
    [Route("GetForManagement")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>>> GetAllProductsForManager()
    {
        var products = await _productService.GetAllProductsFromBase();
        return Ok(products);
    }

    [HttpGet]
    [Route("productDetails/{id}")]
    public async Task<ActionResult<BaseResponse<GetProductDetailForHP>>> GetProductDetailForHomePage(int id)
    {
        return await _productService.GetProductByIdFromBase(id);
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<BaseResponse<Product>>> DeleteProduct(int id)
    {
        var existingProduct = await _productService.GetProductByIdFromBase(id);
        if (existingProduct == null)
        {
            return NotFound(new { message = "Product not found" });
        }

        var success = await _productService.DeleteTest(id);

        if (!success)
        {
            return BadRequest(new { message = "Failed to delete product" });
        }

        return Ok(new { message = "Delete successful" });
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPut]
    [Route("UpdateForManagement")]
    public async Task<ActionResult<BaseResponse<UpdateProductRequest>>> UpdateProductFromBase(int id,
        [FromBody] UpdateProductRequest product)
    {
        return await _productService.UpdateProductFromBase(id, product);
    }

    /*[Authorize(Roles = "Manager")]*/
    [HttpPost]
    [Route("AddForManagement")]
    public async Task<ActionResult<BaseResponse<AddProductRequest>>> CreateProductFromBase([FromBody] AddProductRequest request)
    {
        var newProduct = await _productService.AddProductByIdFromBase(request);
        return newProduct;
    }

    [HttpGet]
    [Route("base/getProducts")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetFilterProductResponse>>>> GetProductsAsync(string? search, double? lowPrice, double? highPrice, int? category, string? sortBy, int? pageIndex,
        int? pageSize)
    {
        return await _productService.GetProductsAsync(search, lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
    }

    /*[Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("base/GetTopProductInMonth")]
    public async Task<BaseResponse<List<GetTopProductSoldInAMonth>>> GetTopProductsSoldInMonthAsync(int top)
    {
        var result = await _productService.GetTopProductsSoldInMonthAsync(top);
        return result;
    }*/

   /* [Authorize(Roles = "Manager")]*/
    [HttpGet]
    [Route("base/getProductsForManager")]
    public async Task<BaseResponse<SearchProductResponse>> SearchProductAsync(string? search, int pageIndex, int pageSize)
    {
        return await _productService.SearchProductAsync(search, pageIndex, pageSize);
    }
}

