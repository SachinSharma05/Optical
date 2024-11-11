using api.Abstraction.Services;
using api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetProductType")]
        public async Task<IActionResult> GetProductType()
        {
            try
            {
                var result = await _categoryService.GetProductType();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetCategoryType")]
        public async Task<IActionResult> GetCategoryType()
        {
            try
            {
                var result = await _categoryService.GetCategoryType();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetSubCategoryType")]
        public async Task<IActionResult> GetSubCategoryType()
        {
            try
            {
                var result = await _categoryService.GetSubCategoryType();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetTaxCategories")]
        public async Task<IActionResult> GetTaxCategories()
        {
            try
            {
                var result = await _categoryService.GetTaxCategories();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductType product)
        {
            var result = await _categoryService.CreateProduct(product);
            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var result = await _categoryService.CreateCategory(category);
            return Ok(result);
        }

        [HttpPost("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategory(SubCategory subCategory)
        {
            var result = await _categoryService.CreateSubCategory(subCategory);
            return Ok(result);
        }

        [HttpPost("CreateTaxCategory")]
        public async Task<IActionResult> CreateTaxCategory(TaxCategory taxCategory)
        {
            var result = await _categoryService.CreateTaxCategory(taxCategory);
            return Ok(result);
        }

        [HttpPost("CreateInventory")]
        public async Task<IActionResult> CreateInventory(InventoryMaster inventory)
        {
            var result = await _categoryService.CreateInventory(inventory);
            return Ok(result);
        }

        [HttpGet("GetInventoryList")]
        public async Task<IActionResult> GetInventoryList(int page, int pageSize)
        {
            var result = await _categoryService.GetInventoryList(page, pageSize);
            return Ok(new
            {
                items = result.Items,
                totalItems = result.TotalItems
            });
        }

        [HttpDelete("DeleteInventoryById")]
        public async Task<IActionResult> DeleteInventoryById(string id)
        {
            var result = await _categoryService.DeleteInventoryById(id);
            return Ok(result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(InventoryMaster update)
        {
            var result = await _categoryService.UpdateProduct(update);
            return Ok(result);
        }
    }
}
