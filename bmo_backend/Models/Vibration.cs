using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Vibration
    {
        [Key]
        public long Id { get; set; }

        [Column("id_Running")]
        public long Id_Running { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("vibration")]
        public float VibrationValue { get; set; }
    }
}
