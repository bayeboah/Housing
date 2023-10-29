using Housing.Configuration.Entities;
using Microsoft.EntityFrameworkCore;

namespace Housing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new HousingConfiguration());
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<State> States { get; set; }



    }
}
