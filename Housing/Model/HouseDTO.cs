using System.ComponentModel.DataAnnotations;
using Housing.Data;

namespace Housing.Model
{
    public class HouseDTO :CreateHouseDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }


    }

    public class CreateHouseDTO
    {
        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1,5,ErrorMessage = "Range is between in 1and 5")]
        public double Rating { get; set; }

        [Required]
        public string  Size { get; set; }

        [Required]
        public int NumberOfRoooms { get; set; }

        [Required]
        public string State { get; set; }

    }
}
