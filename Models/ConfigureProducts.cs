using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    public class ConfigureProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "TRNY10",
                    Name = "Tournament Master 1.0",
                    YearlyPrice = 4.99,
                    ReleaseDate = DateTime.Now
                }
                );

        }
    }
}
