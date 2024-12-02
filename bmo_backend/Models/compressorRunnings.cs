using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class CompressorRunning
    {
        [Key]
        public int RunningId { get; set; }

        public int CompressorId { get; set; }

        public double? Temperature { get; set; }

        public double? Vibration { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
