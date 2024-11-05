using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        public string Type { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
    }
}
