using sensade_project.DatabaseLayer;
using sensade_project.EfCore;
using sensade_project.ModelLayer;
using System;

namespace sensade_project.BusinessLayer
{
    public class ParkingAreaBusiness : IParkingAreaBusiness
    {
        IParkingAreaAccess _parkingAccess;
        public ParkingAreaBusiness(DataContext dataContext)
        {
            _parkingAccess = new ParkingAreaAccess(dataContext);
        }

        public int AvailableParkingSpaces(int id)
        {
            int result = _parkingAccess.AvailableParkingSpaces(id);
            return result;
        }

        public bool CreateParkingArea(ParkingAreaModel parkingAreaModel)
        {
            try
            {
                _parkingAccess.CreateParkingArea(parkingAreaModel);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteParkingArea(int id)
        {
            try
            {
                _parkingAccess.DeleteParkingArea(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<ParkingAreaModel>? GetAllAreas()
        {
            List<ParkingAreaModel>? foundAreas;
            try
            {
                foundAreas = _parkingAccess.GetAllAreas();
            }
            catch
            {
                foundAreas = null;
            }
            return foundAreas;
        }

        public ParkingAreaModel? GetParkingArea(int id)
        {
            ParkingAreaModel foundArea;
            try
            {
                foundArea = _parkingAccess.GetParkingArea(id);
            }
            catch
            {
                foundArea = null;
            }
            return foundArea;
        }

        public int ParkingSpaces(int id)
        {
            int result = _parkingAccess.ParkingSpaces(id);
            return result;
        }

        public bool UpdateParkingArea(ParkingAreaModel parkingAreaModel, int id)
        {
            try
            {
                _parkingAccess.UpdateParkingArea(parkingAreaModel, id);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
