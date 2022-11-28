using CtcontrolAPIService.Validation;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CtcontrolAPIService.Services
{
    public class ClientDataModel
    {
        [BsonId]
        public string? Id { get; set; }

        [Range(0, 31, ErrorMessage ="Unacceptable day number")]
        public int DateNumber { get; set; }

        [Month]
        public string DateMonth { get; set; } = null!;

        [Range(0, 3000, ErrorMessage = "Unacceptable year number")]
        public int DateYear { get; set; }
        [Time]
        public string Time { get; set; } = null!;

        [Day]
        public string Day { get; set; } = null!;

        [Range(0, 365, ErrorMessage = "Unacceptable day number")]
        public int WorktimeDay { get; set; }

        [Range(0, 24, ErrorMessage = "Unacceptable hour")]
        public int WorktimeHour { get; set; }

        [Range(0, 60, ErrorMessage = "Unacceptable minut")]
        public int WorktimeMinute { get; set;}

        [Range(0, 60, ErrorMessage = "Unacceptable second")]
        public int WorktimeSecond { get; set;}

        [Range(0, 100, ErrorMessage = "Unacceptable batary charge")]
        public int? Batary { get; set; }

        [Range(0, 120, ErrorMessage = "Unacceptable cpu temperature")]
        public int CpuTemperature { get; set; }

        [Range(0, 120, ErrorMessage = "Unacceptable gpu temperature")]
        public int? GpuTemperature { get; set; }
    }
}