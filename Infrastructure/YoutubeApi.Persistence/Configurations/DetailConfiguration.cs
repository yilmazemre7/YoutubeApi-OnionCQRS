using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Detail detail1 = new Detail
            {
                Id = 1,
                Title = "Akıllı Telefon Özellikleri",
                Description = "En son teknoloji akıllı telefon özellikleri ve detayları",
                CategoryId = 1
            };
            Detail detail2 = new Detail
            {
                Id = 2,
                Title = "Moda Trendleri",
                Description = "2024 yılının en popüler moda trendleri ve stil önerileri",
                CategoryId = 2,
                IsDeleted = true
            };
            Detail detail3 = new Detail
            {
                Id = 3,
                Title = "Tablet Özellikleri",
                Description = "Tablet bilgisayarların teknik özellikleri ve kullanım alanları",
                CategoryId = 1
            };
            builder.HasData(detail1, detail2, detail3);
        }
    }
}
