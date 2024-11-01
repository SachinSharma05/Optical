using api.Entities;

namespace api.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductType>> GetProductType();
        Task<IEnumerable<Category>> GetCategoryType();
        Task<IEnumerable<SubCategory>> GetSubCategoryType();
        Task<IEnumerable<TaxCategory>> GetTaxCategories();

    }
}
