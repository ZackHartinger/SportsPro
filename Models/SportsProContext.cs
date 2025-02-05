using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace SportsPro.Models
{ 
    public class SportsProContext : IdentityDbContext<User>
    {
        public SportsProContext(DbContextOptions<SportsProContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigureCustomerProducts());
            modelBuilder.ApplyConfiguration(new ConfigureCustomers());
            modelBuilder.ApplyConfiguration(new ConfigureIncidents());
            modelBuilder.ApplyConfiguration(new ConfigureProducts());
            modelBuilder.ApplyConfiguration(new ConfigureTechnician());            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

        }
    }
}

