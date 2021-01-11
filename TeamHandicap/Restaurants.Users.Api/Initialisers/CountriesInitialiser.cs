using Microsoft.EntityFrameworkCore;
using Restaurants.Users.Api.Models.EntityModels;

namespace Restaurants.Users.Api.Initialisers
{
    public static class CountriesInitialiser
    {
        public static void InitializeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 1, Name = "India", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_1.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 14, Name = "Australia", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_14.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 30, Name = "Brasil", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_30.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 37, Name = "Canada", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_37.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 42, Name = "Chile", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_42.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 54, Name = "Czech Republic", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_54.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 94, Name = "Indonesia", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_94.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 97, Name = "Ireland", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_97.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 99, Name = "Italy", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_99.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 112, Name = "Lebanon", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_112.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 123, Name = "Malaysia", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_123.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 148, Name = "New Zealand", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_148.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 162, Name = "Philippines", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_162.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 163, Name = "Poland", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_163.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 164, Name = "Portugal", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_164.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 166, Name = "Qatar", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_166.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 184, Name = "Singapore", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_184.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 185, Name = "Slovakia", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_185.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 189, Name = "South Africa", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_189.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 191, Name = "Sri Lanka", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_191.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 208, Name = "Turkey", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_208.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 214, Name = "UAE", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_214.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 215, Name = "United Kingdom", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_215.png" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Id = 216, Name = "United States", FlagUrl = "https://b.zmtcdn.com/images/countries/flags/country_216.png" });
        }
    }
}
