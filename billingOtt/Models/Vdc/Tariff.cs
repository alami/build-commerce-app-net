﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace billingOtt.Models.Vdc
{
    [Table("tariffs")]
    public partial class Tariff
    {
        public Tariff()
        {
            AccountTariffs = new HashSet<AccountTariff>();
            TariffAttributes = new HashSet<TariffAttribute>();
            TariffLocales = new HashSet<TariffLocale>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        [StringLength(70)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// 1 - default 2 - constructed
        /// </summary>
        [Column("type")]
        public short Type { get; set; }
        [Column("created_at")]
        public Instant CreatedAt { get; set; }
        [Column("updated_at")]
        public Instant? UpdatedAt { get; set; }
        [Column("status")]
        public short? Status { get; set; }

        [InverseProperty(nameof(AccountTariff.TariffIdTariffs))]
        public virtual ICollection<AccountTariff> AccountTariffs { get; set; }
        [InverseProperty(nameof(TariffAttribute.TarifIdTariffs))]
        public virtual ICollection<TariffAttribute> TariffAttributes { get; set; }
        [InverseProperty(nameof(TariffLocale.TariffIdTariffsNavigation))]
        public virtual ICollection<TariffLocale> TariffLocales { get; set; }
    }
}