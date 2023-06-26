using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleID);
            builder.Property(s => s.Date)
                .HasColumnName("Date")
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()");
            builder
                .HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.ProductID);
            builder
                .HasOne(c => c.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(c => c.CustomerID);
            builder
                .HasOne(s => s.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.StoreID);
            new SaleSeeder().Seed(builder);
        }
    }
}