// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace billingOtt.Models.Vdc
{
    [Keyless]
    [Table("settings")]
    public partial class Setting
    {
        [Column("billing_id")]
        public Guid? BillingId { get; set; }
    }
}