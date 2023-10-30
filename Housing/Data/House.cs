using System.ComponentModel.DataAnnotations.Schema;

namespace Housing.Data
{
    public class House
    {
        public int Id { get; set; }

        public string Address { get; set; }


        public double Rating { get; set; }

        public String State { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public string Size { get; set; }

        public int NumberOfRooms { get; set; }

    }
}
