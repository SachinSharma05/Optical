using api.Abstraction.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Catgories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategoryType()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductType()
        {
            try
            {
                return await _context.ProductType.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryType()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<IEnumerable<TaxCategory>> GetTaxCategories()
        {
            return await _context.TaxCategories.ToListAsync();
        }
    }
}
