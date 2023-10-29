using Housing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Configuration.Entities
{
    public class HousingConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                
                new House
                {
                    Id = 1,
                    Address = "BA 213445 street",
                    State = "Massachusetts",
                    CountryId = 1,
                    Size = " 2400x2000x5000",
                    NumberOfRooms = 4
                },

                new House
                {
                    Id = 2,
                    Address = "AD 093848 paddington",
                    State = "Adelaide",
                    CountryId = 3,
                    Size = " 24000x60000x50000",
                    NumberOfRooms = 5
                },
                new House
                {
                    Id = 3,
                    Address = "Nc 445 street pittsburg",
                    State = "NewCastle",
                    CountryId = 2,
                    Size = " 24000x30000x80000",
                    NumberOfRooms = 6
                }


                );
        }
    }
}
