using System.ComponentModel.DataAnnotations.Schema;

namespace Housing.Data
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }

        public int StateCode { get; set; }

        public string Population { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
