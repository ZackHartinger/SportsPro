using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    public class ConfigureTechnician : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
                new Technician
                {
                    TechnicianId = 1,
                    Name = "Alison Diaz",
                    Email = "alison@sportprosoftware.com",
                    PhoneNumber = "800-555-0443"
                },
                new Technician
                {
                    TechnicianId = 2,
                    Name = "Andrew Wilson",
                    Email = "awilson@sportprosoftware.com",
                    PhoneNumber = "800-555-0449"

                },
                new Technician
                {
                    TechnicianId = 3,
                    Name = "Gina Fiori",
                    Email = "gfiori@sportprosoftware.com",
                    PhoneNumber = "800-555-0459"
                },
                new Technician
                {
                    TechnicianId = 4,
                    Name = "Gunter Wendt",
                    Email = "gunter@sportprosoftware.com",
                    PhoneNumber = "800-555-0400"
                },
                new Technician
                {
                    TechnicianId = 5,
                    Name = "Jason Lee",
                    Email = "jason@sportprosoftware.com",
                    PhoneNumber = "800-555-0440"
                }
                );
        }
    }
}
