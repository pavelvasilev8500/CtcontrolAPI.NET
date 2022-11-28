using CtcontrolAPIService.Validation;
using MongoDB.Bson.Serialization.Attributes;

namespace CtcontrolAPIService.Models
{
    public class StatusDataModel
    {
        [BsonId]
        public string? Id { get; set; }
        [Status]
        public string? Status { get; set; }
        [ComputerType]
        public string PCType { get; set; } = null!;
    }
}
