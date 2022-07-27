namespace found_church_api.Models
{
    public class FoundChurchDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ChurchesCollectionName { get; set; } = null!;
    }
}
