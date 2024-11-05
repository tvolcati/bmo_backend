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
        public float MaxTemperature { get; set; }
        [Column("maxVibration")]
        public float MaxVibration { get; set; }
    }
}