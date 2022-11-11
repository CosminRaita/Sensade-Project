namespace sensade_project.ModelLayer
{
    public class ParkingAreaModel
    {
        public int ID { get; set; }

        public string StreetAddress { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public int Longitude { get; set; }

        public int Latitude { get; set; }
    }
}
