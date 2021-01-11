using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// using Restaurants.Users.Api.Initialisers;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class AppDbContext : IdentityDbContext<AppUserModel>
    {
        public DbSet<FileModel> Files { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<StateModel> States { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<UserFavouriteModel> UserFavourites { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CountriesInitialiser.InitializeData(modelBuilder);
            // StatesInitialiser.InitializeData(modelBuilder);
            // CitiesInitialiser.InitializeData(modelBuilder);
        }
    }
}
