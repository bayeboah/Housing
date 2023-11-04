using Housing.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Housing.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new HousingConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<State> States { get; set; }



    }
}
