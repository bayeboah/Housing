using System.ComponentModel.DataAnnotations;

namespace Housing.Model
{


    public class CountryDTO : CreateCountryDTO
    {

        public int Id { get; set; }

        public virtual IList<StateDTO> States { get; set; }

        public virtual IList<HouseDTO> Houses { get; set; }
    }


    public class CreateCountryDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is Too Long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "It is too long.")]
        public string shortName { get; set; }
    }
}
