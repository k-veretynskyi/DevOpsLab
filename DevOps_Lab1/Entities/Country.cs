namespace DevOps_Lab1.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Continent { get; set; } = string.Empty;
        public string Language {  get; set; } = string.Empty;
        public ICollection<City> Cities { get; set;}
    }
}
