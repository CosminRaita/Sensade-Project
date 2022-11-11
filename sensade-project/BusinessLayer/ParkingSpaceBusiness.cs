using sensade_project.DatabaseLayer;
using sensade_project.EfCore;
using sensade_project.ModelLayer;

namespace sensade_project.BusinessLayer
{
    public class ParkingSpaceBusiness : IParkingSpaceBusiness
    {
        IParkingSpaceAccess _parkingAccess;
        public ParkingSpaceBusiness(DataContext dataContext)
        {
            _parkingAccess = new ParkingSpaceAccess(dataContext);
        }

        public bool CreateParkingSpace(ParkingSpaceModel parkingSpaceModel, int parkingAreaId)
        {
            try
            {
                _parkingAccess.CreateParkingSpace(parkingSpaceModel, parkingAreaId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteParkingSpace(int id)
        {
            try
            {
                _parkingAccess.DeleteParkingSpace(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<ParkingSpaceModel>? GetAllSpaces()
        {
            List<ParkingSpaceModel>? foundSpaces;
            try
            {
                foundSpaces = _parkingAccess.GetAllSpaces();
            }
            catch
            {
                foundSpaces = null;
            }
            return foundSpaces;
        }

        public ParkingSpaceModel? GetParkingSpace(int id)
        {
            ParkingSpaceModel foundSpace;
            try
            {
                foundSpace = _parkingAccess.GetParkingSpace(id);
            }
            catch
            {
                foundSpace = null;
            }
            return foundSpace;
        }

        public bool setStatus(int id, string status)
        {
            try
            {
                return _parkingAccess.setStatus(id, status);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateParkingSpace(ParkingSpaceModel parkingSpaceModel, int id, int parkingAreaId)
        {
            try
            {
                _parkingAccess.UpdateParkingSpace(parkingSpaceModel, id, parkingAreaId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
