using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    public class ConfigureCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Email = "kanthoni@pge.com",
                    City = "San Francisco"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Email = "ania@mma.nidc.com",
                    City = "Washington"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Gonzalo",
                    LastName = "Keeton",
                    Email = "",
                    City = "Mission Viejo"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Anton",
                    LastName = "Mauro",
                    Email = "amauro@yahoo.org",
                    City = "Sacramento"
                }
                );
        }
    }
}
