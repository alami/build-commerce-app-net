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
    [Table("account_tariffs")]
    public partial class AccountTariff
    {
        [Column("id")]
        public long Id { get; set; }
        [Key]
        [Column("account_number")]
        [StringLength(16)]
        public string AccountNumber { get; set; } = null!;
        [Key]
        [Column("tariff_id")]
        public long TariffId { get; set; }
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("deactivation_type")]
        public int? DeactivationType { get; set; }
        [Column("ends_at")]
        public Instant? EndsAt { get; set; }
        [Column("privileged_period")]
        public int? PrivilegedPeriod { get; set; }
        [Column("tariff_id_tariffs_id")]
        public long TariffIdTariffsId { get; set; }
        [Column("account_number_accounts_account_number")]
        [StringLength(16)]
        public string AccountNumberAccountsAccountNumber { get; set; } = null!;

        [ForeignKey(nameof(AccountNumberAccountsAccountNumber))]
        [InverseProperty(nameof(Account.AccountTariffs))]
        public virtual Account AccountNumberAccountsAccountNumberNavigation { get; set; } = null!;
        [ForeignKey(nameof(TariffIdTariffsId))]
        [InverseProperty(nameof(Tariff.AccountTariffs))]
        public virtual Tariff TariffIdTariffs { get; set; } = null!;
    }
}