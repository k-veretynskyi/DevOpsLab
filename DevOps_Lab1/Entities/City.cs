namespace DevOps_Lab1.Entities
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int FoundationYear { get; set; } 
        public int PostCode {  get; set; }
        public int CountryId { get; set; }
        public ICollection<SuperHero> SuperHeroes { get; set; }
    }
}
