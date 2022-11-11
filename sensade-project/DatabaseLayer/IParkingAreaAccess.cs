using sensade_project.ModelLayer;

namespace sensade_project.DatabaseLayer
{
    public interface IParkingAreaAccess
    {
        List<ParkingAreaModel>? GetAllAreas();

        ParkingAreaModel? GetParkingArea(int id);

        bool CreateParkingArea(ParkingAreaModel parkingAreaModel);

        bool UpdateParkingArea(ParkingAreaModel parkingAreaModel, int id);

        bool DeleteParkingArea(int id);

        int ParkingSpaces(int id);

        int AvailableParkingSpaces(int id);
    }
}
