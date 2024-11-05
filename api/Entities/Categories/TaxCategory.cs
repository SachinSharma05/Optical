using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class TaxCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tax_percent")]
        public string TaxPercent { get; set; }
    }
}
