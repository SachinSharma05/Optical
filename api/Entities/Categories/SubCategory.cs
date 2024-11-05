using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class SubCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("subCategory_name")]
        public string SubCategoryName { get; set; }
    }
}
