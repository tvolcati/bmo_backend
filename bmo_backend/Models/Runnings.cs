using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Runnings
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("id_Machine")]
        public long Id_Machine { get; set; }

        [Column("typeError")]
        public string? TypeError { get; set; } = string.Empty;

        [Column("meanTemperature")]
        public float? MeanTemperature { get; set; }

        [Column("meanVibration")]
        public float? MeanVibration { get; set; }

        [Column("distanceTraveled")]
        public float? DistanceTraveled { get; set; }

        [Column("start_timestamp")]
        public DateTime StartTimestamp { get; set; }

        [Column("end_timestamp")]
        public DateTime? EndTimestamp { get; set; }
    }
}
