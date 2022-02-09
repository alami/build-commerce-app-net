using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Billing
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [Column("account_number")]
        [StringLength(16)]
        public string AccountNumber { get; set; } = null!;
        [Column("status")]
        public short Status { get; set; }
        /// <summary>
        /// 1 - individual 2- organization 
        /// </summary>
        [Column("person_type")]
        public short PersonType { get; set; }
        [Column("created_at")]
        public Instant CreatedAt { get; set; }
        [Column("updated_at")]
        public Instant? UpdatedAt { get; set; }

    }
}
