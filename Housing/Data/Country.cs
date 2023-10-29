namespace Housing.Data
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string ShortName { get; set; }

        public virtual IList<State> States { get; set; }

        public virtual IList<House>Houses { get; set; }

    }
}
