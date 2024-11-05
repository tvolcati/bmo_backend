using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmo_backend.Models
{
    public class Runnings
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("id_running")]
        public long Id_running { get; set; }
        [Column("typeError")]
        public string TypeError { get; set; } = string.Empty;
        [Column("meanTemperature")]
        public float MeanTemperature { get; set; }
        [Column("meanVibration")]
        public float MeanVibration { get; set; }
        [Column("start_timestamp")]
        public DateTime StartTimestamp { get; set; }
        [Column("end_timestamp")]
        public DateTime EndTimestamp { get; set; }
    }
}
