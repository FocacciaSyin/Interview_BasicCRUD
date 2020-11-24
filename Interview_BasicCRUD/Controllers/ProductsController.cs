using AutoMapper;
using Interview_BasicCRUD.Dto;
using Interview_BasicCRUD.Models;
using Interview_BasicCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepositroy _productRepositroy;
        private readonly IMapper _mapper;


        public ProductsController(
            IProductRepositroy productRepositroy,
            IMapper mapper)
        {
            _productRepositroy = productRepositroy;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productList = await _productRepositroy.GetProductsAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productList));
        }

        [HttpGet("{productId}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid productId)
        {
            var isProductExist = await _productRepositroy.ProductExistsAsync(productId);
            if (!isProductExist)
                return NotFound("使用產品Id查無資料");

            var productItem = await _productRepositroy.GetProductByIdAsync(productId);
            return Ok(_mapper.Map<ProductDto>(productItem));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductForCreateDto productForCreateDto)
        {
            var product = _mapper.Map<Product>(productForCreateDto);
            await _productRepositroy.AddProduct(product);
            await _productRepositroy.SaveAsync();
            var productResult = _mapper.Map<ProductDto>(product);

            return CreatedAtRoute("GetProductById",
                new { ProductId = productResult.Id },
                productResult);

        }


        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {

            var isProductExist = await _productRepositroy.ProductExistsAsync(productId);
            if (!isProductExist)
                return NotFound("使用產品Id查無資料");

            var productItem = await _productRepositroy.GetProductByIdAsync(productId);
            await _productRepositroy.DeleteProduct(productItem);
            await _productRepositroy.SaveAsync();

            return NoContent();
        }


    }
}
