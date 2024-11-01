using api.Abstraction.Services;
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
    }
}
