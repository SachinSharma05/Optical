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

        public async Task<bool> CreateCategory(Category category)
        {
            try
            {
                var categories = new Category
                {
                    Type = category.Type,
                    CategoryName = category.CategoryName
                };

                _context.Category.Add(categories);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateInventory(InventoryMaster inventory)
        {
            try
            {
                var inventories = new InventoryMaster
                {
                    product_type = inventory.product_type,
                    category_name = inventory.category_name,
                    sub_category_name = inventory.sub_category_name,
                    product_name = inventory.product_name,
                    selling_price = inventory.selling_price,
                    stock_reorder_point = inventory.stock_reorder_point,
                    stock_limit = inventory.stock_limit,
                    tax_category = inventory.tax_category,
                    stock_in_hand = inventory.stock_in_hand,
                    created_on = DateTime.Now
                };

                _context.InventoryMaster.Add(inventories);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateProduct(ProductType product)
        {
            try
            {
                var type = new ProductType
                {
                    ProductName = product.ProductName,
                };

                _context.ProductType.Add(type);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateSubCategory(SubCategory subCategory)
        {
            try
            {
                var subCategories = new SubCategory
                {
                    SubCategoryName = subCategory.SubCategoryName,
                };

                _context.SubCategory.Add(subCategories);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateTaxCategory(TaxCategory taxCategory)
        {
            try
            {
                var taxCategories = new TaxCategory
                {
                    TaxPercent = taxCategory.TaxPercent
                };

                _context.Tax_Category.Add(taxCategories);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryType()
        {
            try
            {
                return await _context.Category.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<InventoryMaster>> GetInventoryList()
        {
            try
            {
                List<InventoryMaster> list = new List<InventoryMaster>();

                var result = await _context.InventoryMaster.ToListAsync();

                foreach (var item in result)
                {
                    var response = new InventoryMaster
                    {
                        product_type = item.product_type,
                        category_name = item.category_name,
                        sub_category_name = item.sub_category_name,
                        product_name = item.product_name,
                        selling_price = item.selling_price,
                        stock_reorder_point = item.stock_reorder_point,
                        stock_limit = item.stock_limit,
                        stock_in_hand = item.stock_in_hand,
                        tax_category = item.tax_category
                    };

                    list.Add(response);
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                return await _context.SubCategory.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TaxCategory>> GetTaxCategories()
        {
            try
            {
                return await _context.Tax_Category.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
