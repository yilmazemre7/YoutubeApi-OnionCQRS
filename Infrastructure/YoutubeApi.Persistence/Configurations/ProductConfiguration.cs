using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Discount).HasColumnType("decimal(18,2)");
            Product product1 = new()
            {
                Id = 1,
                Title = "IPhone 14 Pro",
                Description = "Apple IPhone 14 Pro Max 256GB",
                BrandId = 1,
                Discount = 0.10m,
                Price = 1999.99m,
            };
            Product product2 = new()
            {
                Id = 2,
                Title = "Samsung Galaxy S23",
                Description = "Samsung Galaxy S23 Ultra 512GB",
                BrandId = 2,
                Discount = 0.15m,
                Price = 1899.99m,
            };
            Product product3 = new()
            {
                Id = 3,
                Title = "MacBook Pro",
                Description = "Apple MacBook Pro M2 1TB",
                BrandId = 1,
                Discount = 0.05m,
                Price = 2999.99m,
            };
            builder.HasData(product1, product2, product3);
        }

    }
}
