using api.Entities;

namespace api.Abstraction.Data
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ProductType>> GetProductType();
        Task<IEnumerable<Category>> GetCategoryType();
        Task<IEnumerable<SubCategory>> GetSubCategoryType();
        Task<IEnumerable<TaxCategory>> GetTaxCategories();

    }
}
