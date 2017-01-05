namespace SimplifiedEfTest.DTO
{
    public class CityData : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int? Population { get; set; }
    }
}