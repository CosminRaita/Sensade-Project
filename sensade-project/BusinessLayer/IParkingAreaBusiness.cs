using sensade_project.ModelLayer;

namespace sensade_project.BusinessLayer
{
    public interface IParkingAreaBusiness
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
