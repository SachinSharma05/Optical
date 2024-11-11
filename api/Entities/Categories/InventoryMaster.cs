using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class InventoryMaster
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("productType")]
        public string productType { get; set; }
        [Column("categoryName")]
        public string categoryName { get; set; }
        [Column("subCategoryName")]
        public string subCategoryName { get; set; }
        [Column("productName")]
        public string productName { get; set; }
        [Column("sellingPrice")]
        public string sellingPrice { get; set; }
        [Column("stockReorderPoint")]
        public string stockReorderPoint { get; set; }
        [Column("stockLimit")]
        public string stockLimit { get; set; }
        [Column("taxCategory")]
        public string taxCategory {  get; set; }
        [Column("stockInHand")]
        public string stockInHand { get; set; }
        [Column("createdOn")]
        public DateTime createdOn { get; set; }
    }
}
