namespace DevOps_Lab1.Entities
{
    public class SuperHero
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CityId { get; set; }
    }
}
