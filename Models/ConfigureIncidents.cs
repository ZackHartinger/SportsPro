using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsPro.Models
{
    public class ConfigureIncidents : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(
                new Incident
                {
                    IncidentId = 1,
                    Title = "Could not install",
                    Description = "Program fails to install.",
                    CustomerId = 1,
                    TechnicianId = 1,
                    ProductId = 1
                }
                );
        }
    }
}
