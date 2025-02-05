using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    public class ConfigureCustomerProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasMany(p => p.Customers)
                .WithMany(c => c.Products)
                .UsingEntity(
                    pc => pc.HasData(
                        new { ProductsProductId = 1, CustomersCustomerId = 1 },
                        new { ProductsProductId = 1, CustomersCustomerId = 4 },
                        new { ProductsProductId = 1, CustomersCustomerId = 6 }
                    ));
        }
    }
}
