using Housing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Configuration.Entities
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                
                new State
                {
                    Id = 1,
                    StateName = "Newcastle",
                    StateCode = 000244,
                    CountryId = 2,
                    Population = "23 million"

                },
                new State
                {
                    Id = 2,
                    StateName = "Adelaide",
                    StateCode = 22280,
                    CountryId = 3,
                    Population = "16 million"

                },
                new State
                {
                    Id = 3,
                    StateName = "Massachusetts",
                    StateCode = 00553,
                    CountryId = 1,
                    Population = "60 million"

                }

                );
        }
    }
}
