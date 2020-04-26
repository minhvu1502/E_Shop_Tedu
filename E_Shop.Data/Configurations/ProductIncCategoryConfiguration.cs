using System;
using System.Collections.Generic;
using System.Text;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Shop.Data.Configurations
{
    class ProductIncCategoryConfiguration: IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.CategoryId});
            builder.ToTable("ProductInCategories");
            builder.HasOne(x => x.Product).WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
