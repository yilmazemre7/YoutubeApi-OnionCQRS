using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class BrandConfiguration:IEntityTypeConfiguration<Brand>
    {
       
public void Configure(EntityTypeBuilder<Brand> builder)
        {
            Brand brand1 = new()
            {
                Id = 1,
                Name = "Apple"
            };
            Brand brand2 = new()
            {
                Id = 2,
                Name = "Samsung"
            };
            Brand brand3 = new()
            {
                Id = 3,
                Name = "Huawei",
                IsDeleted = true
            };

            builder.HasData(brand1, brand2, brand3);
        }
    }

}

