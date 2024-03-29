using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailsService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailsService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var values = await _ProductDetailsService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _ProductDetailsService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _ProductDetailsService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _ProductDetailsService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Ürün detayı başarıyla güncellendi.");
        }
    }
}
