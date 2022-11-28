namespace CtcontrolAPIService.Models
{
    public class MongoDBSettings
    {
        public string? ConnectionURI { get; set; } = null;
        public string? DataBaseName { get; set; } = null;
        public string? ClientCollectionName { get; set; } = null;
        public string? StatusCollectionName { get; set; } = null;
    }
}
