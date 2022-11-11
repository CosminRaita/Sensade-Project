using sensade_project.EfCore;

namespace sensade_project.ModelLayer
{
    public class ParkingSpaceModel
    {
        public int ID { get; set; }

        public string Status { get; set; } = string.Empty;

        public int SpaceNumber { get; set; }

        public int ParkingAreaID { get; set; }
    }
}
