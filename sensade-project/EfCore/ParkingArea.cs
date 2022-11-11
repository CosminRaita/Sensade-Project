using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sensade_project.EfCore
{
    [Table("ParkingArea")]
    public class ParkingArea
    {
        [Key,Required]
        public int ID { get; set; }

        public string StreetAddress { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public int Longitude { get; set; }

        public int Latitude { get; set; }
    }
}
