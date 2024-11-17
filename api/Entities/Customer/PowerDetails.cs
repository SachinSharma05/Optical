using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class CreatePowerRequest
    {
        public CustomerMaster CustomerDetails { get; set; }
        public PowerDetails PowerDetails { get; set; }
    }

    public class PowerDetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customerId")]
        public int customerId { get; set; }

        [Column("remarks")]
        public string remarks { get; set; }

        [Column("rsph")]
        public string rsph {  get; set; }

        [Column("rcyl")]
        public string rcyl { get; set; }

        [Column("raxis")]
        public string raxis { get; set; }

        [Column("rvn")]
        public string rvn { get; set; }

        [Column("radd")]
        public string radd { get; set; }

        [Column("lsph")]
        public string lsph { get; set; }

        [Column("lcyl")]
        public string lcyl { get; set; }

        [Column("laxis")]
        public string laxis { get; set; }

        [Column("lvn")]
        public string lvn { get; set; }

        [Column("ladd")]
        public string ladd { get; set; }

        [Column("pd")]
        public string pd {  get; set; }

        [Column("refBy")]
        public string refBy { get; set; }

        [Column("lensType")]
        public string lensType { get; set; }

        [Column("bookingDate")]
        public DateTime bookingDate { get; set; }

        [Column("prgRight")]
        public string prgRight { get; set; }

        [Column("prgLeft")]
        public string prgLeft { get; set; }

        [Column("ppLeft")]
        public string ppLeft { get; set; }

        [Column("ppRight")]
        public string ppRight { get; set; }

        [Column("ppAdd")]
        public string ppAdd { get; set; }

        [Column("createdOn")]
        public DateTime createdOn { get; set; }
    }

    public class PowerDetailsList
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customerId")]
        public int customerId { get; set; }

        [Column("customerName")]
        public string customerName { get; set; }

        [Column("contactNo")]
        public string contactNo { get; set; }

        [Column("alternateContact")]
        public string alternateContact { get; set; }

        [Column("remarks")]
        public string remarks { get; set; }

        [Column("rsph")]
        public string rsph { get; set; }

        [Column("rcyl")]
        public string rcyl { get; set; }

        [Column("raxis")]
        public string raxis { get; set; }

        [Column("rvn")]
        public string rvn { get; set; }

        [Column("radd")]
        public string radd { get; set; }

        [Column("lsph")]
        public string lsph { get; set; }

        [Column("lcyl")]
        public string lcyl { get; set; }

        [Column("laxis")]
        public string laxis { get; set; }

        [Column("lvn")]
        public string lvn { get; set; }

        [Column("ladd")]
        public string ladd { get; set; }

        [Column("pd")]
        public string pd { get; set; }

        [Column("refBy")]
        public string refBy { get; set; }

        [Column("lensType")]
        public string lensType { get; set; }

        [Column("bookingDate")]
        public DateTime bookingDate { get; set; }

        [Column("prgRight")]
        public string prgRight { get; set; }

        [Column("prgLeft")]
        public string prgLeft { get; set; }

        [Column("ppLeft")]
        public string ppLeft { get; set; }

        [Column("ppRight")]
        public string ppRight { get; set; }

        [Column("ppAdd")]
        public string ppAdd { get; set; }

        [Column("createdOn")]
        public DateTime createdOn { get; set; }
    }
}
