using Microsoft.EntityFrameworkCore;
using Restaurants.Users.Api.Models.EntityModels;

namespace Restaurants.Users.Api.Initialisers
{
    public static class StatesInitialiser
    {
        public static void InitializeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 69, Code = "AK", Name = "Alaska", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 70, Code = "AL", Name = "Alabama", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 71, Code = "AR", Name = "Arkansas", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 72, Code = "AZ", Name = "Arizona", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 73, Code = "CA", Name = "California", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 74, Code = "CO", Name = "Colorado", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 75, Code = "CT", Name = "Connecticut", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 76, Code = "DE", Name = "Delaware", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 77, Code = "FL", Name = "Florida", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 78, Code = "GA", Name = "Georgia", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 80, Code = "IA", Name = "Iowa", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 81, Code = "ID", Name = "Idaho", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 82, Code = "IL", Name = "Illinois", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 83, Code = "IN", Name = "Indiana", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 84, Code = "KS", Name = "Kansas", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 85, Code = "KY", Name = "Kentucky", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 86, Code = "LA", Name = "Louisiana", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 87, Code = "MA", Name = "Massachusetts", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 88, Code = "MD", Name = "Maryland", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 89, Code = "ME", Name = "Maine", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 90, Code = "MI", Name = "Michigan", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 91, Code = "MN", Name = "Minnesota", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 92, Code = "MO", Name = "Missouri", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 93, Code = "MS", Name = "Mississippi", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 94, Code = "MT", Name = "Montana", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 95, Code = "NC", Name = "North Carolina", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 96, Code = "ND", Name = "North Dakota", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 97, Code = "NE", Name = "Nebraska", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 98, Code = "NH", Name = "New Hampshire", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 100, Code = "NJ", Name = "New Jersey", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 101, Code = "NM", Name = "New Mexico", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 102, Code = "NV", Name = "Nevada", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 103, Code = "NY", Name = "New York State", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 104, Code = "OH", Name = "Ohio", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 105, Code = "OK", Name = "Oklahoma", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 106, Code = "OR", Name = "Oregon", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 107, Code = "PA", Name = "Pennsylvania", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 108, Code = "SC", Name = "South Carolina", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 109, Code = "SD", Name = "South Dakota", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 110, Code = "TN", Name = "Tennessee", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 111, Code = "TX", Name = "Texas", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 112, Code = "UT", Name = "Utah", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 113, Code = "VA", Name = "Virginia", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 114, Code = "VT", Name = "Vermont", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 115, Code = "WA", Name = "Washington State", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 116, Code = "WI", Name = "Wisconsin", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 117, Code = "WV", Name = "West Virginia", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 118, Code = "WY", Name = "Wyoming", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 119, Code = "AB", Name = "Alberta", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 121, Code = "BC", Name = "British Columbia", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 122, Code = "MB", Name = "Manitoba", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 124, Code = "ON", Name = "Ontario", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 125, Code = "QC", Name = "Quebec", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 126, Code = "SK", Name = "Saskatchewan", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 127, Code = "TT", Name = "The Territories", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 128, Code = "NSW", Name = "New South Wales", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 129, Code = "NT", Name = "Northern Territory", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 130, Code = "QLD", Name = "Queensland", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 131, Code = "SA", Name = "South Australia", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 132, Code = "VIC", Name = "Victoria", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 133, Code = "WA", Name = "Western Australia", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 134, Code = "Sco", Name = "Scotland", CountryId = 215 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 137, Code = "RI", Name = "Rhode Island", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 138, Code = "DC", Name = "DC", CountryId = 216 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 140, Code = "TAS", Name = "Tasmania", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 141, Code = "ACT", Name = "ACT", CountryId = 14 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 142, Code = "England and Wales", Name = "England and Wales", CountryId = 215 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 143, Code = "Northern Ireland", Name = "Northern Ireland", CountryId = 215 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 144, Code = "NS", Name = "Nova Scotia", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 145, Code = "NB", Name = "New Brunswick", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 146, Code = "PEI", Name = "Prince Edward Island", CountryId = 37 });
            modelBuilder.Entity<StateModel>().HasData(new StateModel { Id = 147, Code = "NL", Name = "Newfoundland and Labrador", CountryId = 37 });
        }
    }
}
