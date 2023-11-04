using System.ComponentModel.DataAnnotations;

namespace Housing.Model
{
    public class StateDTO: CreatestateDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }


    }

    public class CreatestateDTO
    {
        [Required] 
        public string StateName { get; set; }

        [Required]
        [Range(1,6)]
        public int StateCode { get; set; }

        [Required]
        public string population { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
