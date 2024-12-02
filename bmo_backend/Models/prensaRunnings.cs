using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class PrensaRunning
    {
        [Key]
        public int RunningId { get; set; }

        public int PrensaId { get; set; }

        public double? DistanceTraveled { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
