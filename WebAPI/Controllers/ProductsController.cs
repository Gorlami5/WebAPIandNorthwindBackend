using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

       private IProductService _productservice;

        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet("getall")]

        public IActionResult GetList()
        {

            var result = _productservice.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getcategoryid")]

        public IActionResult getcategoryId(int categoryId)
        {
            var result = _productservice.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getproductid")]
        public IActionResult getproductId(int id)
        {
            var result = _productservice.GetByProductId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addproduct")]

        public IActionResult addProduct(Product product)
        {
            var result = _productservice.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("deleteproduct")]

        public IActionResult deleteProduct(Product product)
        {
            var result = _productservice.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

    }
}
