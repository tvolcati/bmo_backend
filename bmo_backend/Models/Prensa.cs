using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bmo_backend.Models
{
    public class Prensa
    {
        [Key]
        public int Id { get; set; }

        public int? NumberOfFailures { get; set; }

        public double? MaximumDistance { get; set; }

        public DateTime? LastMaintenance { get; set; }

        public double? OperatingTime { get; set; }

        public string? OilQuality { get; set; }

        // Navigation property
        public ICollection<PrensaRunning> PrensaRunnings { get; set; }
    }
}
