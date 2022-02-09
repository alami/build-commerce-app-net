﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace billingOtt.Models.Vdc
{
    [Table("tariff_locales")]
    public partial class TariffLocale
    {
        [Key]
        [Column("tariff_id")]
        public long TariffId { get; set; }
        [Key]
        [Column("locale")]
        [StringLength(2)]
        public string Locale { get; set; } = null!;
        [Column("name")]
        [StringLength(70)]
        public string Name { get; set; } = null!;
        [Column("tariff_id_tariffs")]
        public long TariffIdTariffs { get; set; }

        [ForeignKey(nameof(TariffIdTariffs))]
        [InverseProperty(nameof(Tariff.TariffLocales))]
        public virtual Tariff TariffIdTariffsNavigation { get; set; } = null!;
    }
}