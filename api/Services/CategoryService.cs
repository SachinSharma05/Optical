using api.Abstraction.Data;
using api.Abstraction.Services;
using api.Entities;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoryType()
        {
            return await _categoryRepository.GetCategoryType();
        }

        public async Task<IEnumerable<ProductType>> GetProductType()
        {
            return await _categoryRepository.GetProductType();
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryType()
        {
            return await _categoryRepository.GetSubCategoryType();
        }

        public async Task<IEnumerable<TaxCategory>> GetTaxCategories()
        {
            return await _categoryRepository.GetTaxCategories();
        }
    }
}
