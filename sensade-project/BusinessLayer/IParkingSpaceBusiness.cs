using sensade_project.ModelLayer;

namespace sensade_project.BusinessLayer
{
    public interface IParkingSpaceBusiness
    {
        List<ParkingSpaceModel>? GetAllSpaces();

        ParkingSpaceModel? GetParkingSpace(int id);

        bool CreateParkingSpace(ParkingSpaceModel parkingSpaceModel, int parkingAreaId);

        bool UpdateParkingSpace(ParkingSpaceModel parkingSpaceModel, int id, int parkingAreaId);

        bool DeleteParkingSpace(int id);

        bool setStatus(int id, string status);
    }
}
