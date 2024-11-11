using api.Abstraction.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                    productType = inventory.productType,
                    categoryName = inventory.categoryName,
                    subCategoryName = inventory.subCategoryName,
                    productName = inventory.productName,
                    sellingPrice = inventory.sellingPrice,
                    stockReorderPoint = inventory.stockReorderPoint,
                    stockLimit = inventory.stockLimit,
                    taxCategory = inventory.taxCategory,
                    stockInHand = inventory.stockInHand,
                    createdOn = DateTime.Now
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

        public async Task<PaginatedResponse<InventoryMaster>> GetInventoryList(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var paginatedData = await _context.InventoryMaster.Skip(skip).Take(pageSize).ToListAsync();

                int totalItems = await _context.InventoryMaster.CountAsync();
                var response = new PaginatedResponse<InventoryMaster>
                {
                    Items = paginatedData.Select(item => new InventoryMaster
                    {
                        Id = item.Id,
                        productType = item.productType,
                        categoryName = item.categoryName,
                        subCategoryName = item.subCategoryName,
                        productName = item.productName,
                        sellingPrice = item.sellingPrice,
                        stockReorderPoint = item.stockReorderPoint,
                        stockLimit = item.stockLimit,
                        taxCategory = item.taxCategory,
                        stockInHand = item.stockInHand,
                        createdOn = item.createdOn
                    }).ToList(),
                    TotalItems = totalItems,
                    Page = page,
                    PageSize = pageSize
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteInventoryById(string id)
        {
            try
            {
                var result = await _context.InventoryMaster.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.InventoryMaster.Remove(result);
                    await _context.SaveChangesAsync();

                    return true;
                } 
                else
                    return false;
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

        public async Task<bool> UpdateProduct(InventoryMaster update)
        {
            var existingInventory = await _context.InventoryMaster
            .Where(x => x.Id == update.Id)
            .FirstOrDefaultAsync();

            if (existingInventory == null)
            {
                return false;
            }

            try
            {
                existingInventory.productType = update.productType;
                existingInventory.categoryName = update.categoryName;
                existingInventory.subCategoryName = update.subCategoryName;
                existingInventory.productName = update.productName;
                existingInventory.sellingPrice = update.sellingPrice;
                existingInventory.stockReorderPoint = update.stockReorderPoint;
                existingInventory.stockLimit = update.stockLimit;
                existingInventory.taxCategory = update.taxCategory;
                existingInventory.stockInHand = update.stockInHand;

                _context.InventoryMaster.Update(existingInventory);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
