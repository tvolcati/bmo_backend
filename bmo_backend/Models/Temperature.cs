using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Temperature
    {
        [Column("id_running")]
        public long Id_running { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("temperature")]
        public float TemperatureValue { get; set; }
    }
}
