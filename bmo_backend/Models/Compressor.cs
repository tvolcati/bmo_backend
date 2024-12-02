using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bmo_backend.Models
{
    public class Compressor
    {
        [Key]
        public int Id { get; set; }

        public int? NumberOfFailures { get; set; }

        public double? MaximumTemperature { get; set; }

        public double? MaximumVibration { get; set; }

        public DateTime? LastMaintenance { get; set; }

        public double? OperatingTime { get; set; }

        public string? OilQuality { get; set; }

        // Navigation property
        public ICollection<CompressorRunning>? CompressorRunnings { get; set; }
    }
}
