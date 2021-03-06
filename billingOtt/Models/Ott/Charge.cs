// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace billingOtt.Models.Ott
{
    [Table("charges")]
    public partial class Charge
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("account_number", TypeName = "character varying")]
        public string? AccountNumber { get; set; }
        [Column("tariff_id")]
        public long? TariffId { get; set; }
    }
}