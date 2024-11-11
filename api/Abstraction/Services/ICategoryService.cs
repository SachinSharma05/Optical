using api.Entities;

namespace api.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductType>> GetProductType();
        Task<IEnumerable<Category>> GetCategoryType();
        Task<IEnumerable<SubCategory>> GetSubCategoryType();
        Task<IEnumerable<TaxCategory>> GetTaxCategories();

        Task<bool> CreateProduct(ProductType product);
        Task<bool> CreateCategory(Category category);
        Task<bool> CreateSubCategory(SubCategory subCategory);
        Task<bool> CreateTaxCategory(TaxCategory taxCategory);

        Task<bool> CreateInventory(InventoryMaster inventory);
        Task<PaginatedResponse<InventoryMaster>> GetInventoryList(int page, int pageSize);
        Task<bool> DeleteInventoryById(string id);
        Task<bool> UpdateProduct(InventoryMaster update);
    }
}
