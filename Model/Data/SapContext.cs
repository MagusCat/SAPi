using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Model.Data.Instance;
using Model.Models;

namespace Model.Data
{
    public partial class SapContext : DbContext
    {
        public SapContext()
        {
        }

        public SapContext(DbContextOptions<SapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Conversion> Conversions { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                this.ChangeTracker.LazyLoadingEnabled = false;

                // optionsBuilder.UseModel(SapContextModel.Instance);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand)
                    .HasName("PK__Brand__4D3CE128C8C96C5A");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__E548B673D48D5290");
            });

            modelBuilder.Entity<Conversion>(entity =>
            {
                entity.HasKey(e => e.IdConversion)
                    .HasName("PK__Conversi__B8BBCE5A6532139F");

                entity.HasOne(d => d.IdBaseNavigation)
                    .WithMany(p => p.ConversionIdBaseNavigations)
                    .HasForeignKey(d => d.IdBase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_base_unit");

                entity.HasOne(d => d.IdFactorNavigation)
                    .WithMany(p => p.ConversionIdFactorNavigations)
                    .HasForeignKey(d => d.IdFactor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_factor_unit");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.IdInventory)
                    .HasName("PK__Inventor__84080356CB3C6497");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateEntry).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__Log__6CC851FEE62BD27D");

                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_log_user");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__BA39E84F5970E9A1");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("fk_brand");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_category");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unit");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PK__Record__13533D29DACE5571");

                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_product_record");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unit_record");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__3D48441D8099A342");

                entity.Property(e => e.IdRole).ValueGeneratedNever();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit)
                    .HasName("PK__Unit__D01F3DE93E001425");

                entity.Property(e => e.Abbreviation).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__D2D14637A1EED9FC");

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("fk_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
