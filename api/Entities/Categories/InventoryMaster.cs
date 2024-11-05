using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class InventoryMaster
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_type")]
        public string product_type { get; set; }
        [Column("category_name")]
        public string category_name { get; set; }
        [Column("sub_category_name")]
        public string sub_category_name { get; set; }
        [Column("product_name")]
        public string product_name { get; set; }
        [Column("selling_price")]
        public string selling_price { get; set; }
        [Column("stock_reorder_point")]
        public string stock_reorder_point { get; set; }
        [Column("stock_limit")]
        public string stock_limit { get; set; }
        [Column("tax_category")]
        public string tax_category {  get; set; }
        [Column("stock_in_hand")]
        public string stock_in_hand { get; set; }
        [Column("created_on")]
        public DateTime created_on { get; set; }
    }
}
