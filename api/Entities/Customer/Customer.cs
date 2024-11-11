using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class CustomerMaster
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("customerName")]
        public string customerName { get; set; }
        [Column("address")]
        public string address { get; set; }
        [Column("contactNo")]
        public string contactNo { get; set; }
        [Column("alternateContact")]
        public string alternateContact { get; set; }
        [Column("age")]
        public string age { get; set; }
        [Column("gender")]
        public string gender { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("remarks")]
        public string remarks { get; set; }
    }
}
