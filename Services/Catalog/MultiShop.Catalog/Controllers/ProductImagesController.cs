using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImagesService;

        public ProductImagesController(IProductImageService ProductImageservice)
        {
            _ProductImagesService = ProductImageservice;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImagesList()
        {
            var values = await _ProductImagesService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesById(string id)
        {
            var values = await _ProductImagesService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImages(CreateProductImageDto createProductImagesDto)
        {
            await _ProductImagesService.CreateProductImageAsync(createProductImagesDto);
            return Ok("Ürün görselleri başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImages(string id)
        {
            await _ProductImagesService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImageDto updateProductImagesDto)
        {
            await _ProductImagesService.UpdateProductImageAsync(updateProductImagesDto);
            return Ok("Ürün görselleri başarıyla güncellendi.");
        }
    }
}
