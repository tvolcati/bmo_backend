using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Machines
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("needFix")]
        public bool NeedFix { get; set; } = false;

        [Column("maxTemperature")]
        public float? MaxTemperature { get; set; }

        [Column("maxVibration")]
        public float? MaxVibration { get; set; }
        [Column("maxDistanceTraveled")]
        public float? MaxDistanceTraveled { get; set; }

        [Column("oil_quality")]
        public float OilQuality { get; set; }

        [Column("description")]
        public string Description { get; set; } = "Maquina Nova";

        [Column("type")]
        public long Type { get; set; }
    }
}