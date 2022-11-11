using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sensade_project.EfCore
{
    [Table("ParkingSpace")]
    public class ParkingSpace
    {
        [Key,Required]
        public int ID { get; set; }

        public string Status { get; set; } = string.Empty;

        public int SpaceNumber { get; set; }

        public virtual ParkingArea ParkingArea { get; set; }
    }
}
