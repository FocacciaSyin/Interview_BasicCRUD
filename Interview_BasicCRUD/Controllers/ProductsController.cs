using AutoMapper;
using Interview_BasicCRUD.Dto;
using Interview_BasicCRUD.Models;
using Interview_BasicCRUD.ResourceParamaters;
using Interview_BasicCRUD.Services;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetProducts([FromQuery] ProductResourceParamaters paramaters)
        {
            var productList = await _productRepositroy.GetProductsAsync(
                paramaters.ProductName, paramaters.Description
                );
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


        /// <summary>
        /// 更新完整項目
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(
            [FromRoute] Guid productId,
            [FromBody] ProductForUpdateDto productForUpdateDto)
        {
            var isProductExist = await _productRepositroy.ProductExistsAsync(productId);
            if (!isProductExist)
                return NotFound("使用產品Id查無資料");

            var productItem = await _productRepositroy.GetProductByIdAsync(productId);

            _mapper.Map(productForUpdateDto, productItem);
            await _productRepositroy.SaveAsync();

            return CreatedAtRoute("GetProductById",
              new { ProductId = productItem.Id },
              productItem);

            //return NoContent();
        }


        /// <summary>
        /// 更新有傳入值的欄位
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productForUpdateDto"></param>
        /// <returns></returns>
        [HttpPatch("{productId}")]
        public async Task<IActionResult> PatiallyUpdateProduct(
            [FromRoute] Guid productId,
            [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {

            var isProductExist = await _productRepositroy.ProductExistsAsync(productId);
            if (!isProductExist)
                return NotFound("使用產品Id查無資料");

            var productItem = await _productRepositroy.GetProductByIdAsync(productId);

            var productToPatch = _mapper.Map<ProductForUpdateDto>(productItem);
            patchDocument.ApplyTo(productToPatch, ModelState);

            //資料驗證
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productToPatch, productItem);
            await _productRepositroy.SaveAsync();

            return CreatedAtRoute("GetProductById",
              new { ProductId = productItem.Id },
              productItem);
            //return NoContent();
        }


    }
}
