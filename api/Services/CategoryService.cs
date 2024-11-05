using api.Abstraction.Data;
using api.Abstraction.Services;
using api.Entities;
using Azure;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            bool response = await _categoryRepository.CreateCategory(category);
            if (response == false) return false;

            return true;
        }

        public async Task<bool> CreateInventory(InventoryMaster inventory)
        {
            bool response = await _categoryRepository.CreateInventory(inventory);
            if (response == false) return false;

            return true;
        }

        public async Task<bool> CreateProduct(ProductType product)
        {
            bool response = await _categoryRepository.CreateProduct(product);
            if (response == false) return false;

            return true;
        }

        public async Task<bool> CreateSubCategory(SubCategory subCategory)
        {
            bool response = await _categoryRepository.CreateSubCategory(subCategory);
            if (response == false) return false;

            return true;
        }

        public async Task<bool> CreateTaxCategory(TaxCategory taxCategory)
        {
            bool response = await _categoryRepository.CreateTaxCategory(taxCategory);
            if (response == false) return false;

            return true;
        }

        public async Task<IEnumerable<Category>> GetCategoryType()
        {
            return await _categoryRepository.GetCategoryType();
        }

        public async Task<InventoryMaster> GetInventoryList()
        {
            return await _categoryRepository.GetInventoryList();
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
