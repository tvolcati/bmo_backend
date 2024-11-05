using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Vibration
    {
        [Key]
        [Column("id_running")]
        public long Id_running { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("vibration")]
        public float VibrationValue { get; set; }
    }
}
