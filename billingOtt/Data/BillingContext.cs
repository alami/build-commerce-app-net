﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using billingOtt.Models.Billing;

namespace billingOtt.Data
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Balance> Balances { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=54331;Database=ott;Username=postgres;Password=", x => x.UseNodaTime());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("accounts_pkey");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.Property(e => e.PersonType).HasComment("1 - individual 2- organization ");
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Amount).HasDefaultValueSql("0");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Balances)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_accounts_to_balances");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Balances)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services_to_balances");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Adding).HasDefaultValueSql("'{}'::jsonb");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.Property(e => e.ServiceId).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.State).HasComment("1 - in process 2 - paid 3 - not paid");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_accounts_to_invoices");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services_to_invoices");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Adding).HasDefaultValueSql("'{}'::jsonb");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.Property(e => e.Type).HasComment("1 - payme 2- click 3 - upay 4 - bank");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services_to_payments");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}