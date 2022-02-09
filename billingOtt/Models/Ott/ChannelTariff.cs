﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace billingOtt.Models.Ott
{
    [Table("channel_tariffs")]
    public partial class ChannelTariff
    {
        [Key]
        [Column("tariff_id")]
        public long TariffId { get; set; }
        [Key]
        [Column("channel_id")]
        public long ChannelId { get; set; }
        [Column("channel_id_channels_id")]
        public long ChannelIdChannelsId { get; set; }
        [Column("tariff_id_tariffs_id")]
        public long TariffIdTariffsId { get; set; }

        [ForeignKey(nameof(ChannelIdChannelsId))]
        [InverseProperty(nameof(Content.ChannelTariffs))]
        public virtual Content ChannelIdChannels { get; set; } = null!;
        [ForeignKey(nameof(TariffIdTariffsId))]
        [InverseProperty(nameof(Tariff.ChannelTariffs))]
        public virtual Tariff TariffIdTariffs { get; set; } = null!;
    }
}