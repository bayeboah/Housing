﻿using Housing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Configuration.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                
                new Country
                {
                    CountryId = 1,
                    CountryName = "United State",
                    ShortName = "US"
                },

                new Country
                {
                    CountryId = 2,
                    CountryName = "United Kingdom",
                    ShortName = "UK"
                },

                new Country
                {
                    CountryId = 3,
                    CountryName = "Australia",
                    ShortName = "AUS"
                }





                );
        }
    }
}
