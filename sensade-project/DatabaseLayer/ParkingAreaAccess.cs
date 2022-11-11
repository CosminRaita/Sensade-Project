using Microsoft.EntityFrameworkCore;
using sensade_project.EfCore;
using sensade_project.ModelLayer;

namespace sensade_project.DatabaseLayer
{
    public class ParkingAreaAccess : IParkingAreaAccess
    {
        private DataContext _context;

        public ParkingAreaAccess(DataContext context)
        {
            _context = context;
        }

        public int AvailableParkingSpaces(int id)
        {
            int noOfSpaces = 0;

            var found = _context.ParkingAreas.Where(x => x.ID == id).FirstOrDefault();

            var allSpaces = _context.ParkingSpaces.Include(x => x.ParkingArea).Where(x => x.Status.Equals("free")).ToList();

            if (found != null && allSpaces != null)
            {
                allSpaces.ForEach(x =>
                {
                    if (x.ParkingArea.ID == id)
                    { noOfSpaces++; }
                });
            }
            else
            {
                return -1;
            }

            return noOfSpaces;
        }

        public bool CreateParkingArea(ParkingAreaModel parkingAreaModel)
        {
            ParkingArea parkingArea = new ParkingArea(); 
            if(parkingAreaModel != null)
            {
                parkingArea.ID = parkingAreaModel.ID;
                parkingArea.StreetAddress = parkingAreaModel.StreetAddress;
                parkingArea.City = parkingAreaModel.City;
                parkingArea.ZipCode = parkingAreaModel.ZipCode;
                parkingArea.Longitude = parkingAreaModel.Longitude;
                parkingArea.Latitude = parkingAreaModel.Latitude;
                _context.ParkingAreas.Add(parkingArea);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteParkingArea(int id)
        {
            ParkingArea parkingArea = _context.ParkingAreas.Where(x => x.ID == id).FirstOrDefault();
            if(parkingArea != null)
            {
                _context.ParkingAreas.Remove(parkingArea);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public List<ParkingAreaModel>? GetAllAreas()
        {
            List<ParkingAreaModel> result = new List<ParkingAreaModel>();

            var parkingAreas = _context.ParkingAreas.ToList();

            parkingAreas.ForEach(row => result.Add(new ParkingAreaModel() { 
                ID = row.ID, 
                StreetAddress = row.StreetAddress, 
                City = row.City, 
                ZipCode = row.ZipCode, 
                Latitude = row.Latitude, 
                Longitude = row.Longitude }));

            return result;
        }

        public ParkingAreaModel? GetParkingArea(int id)
        {
            ParkingAreaModel result = new ParkingAreaModel();

            var found = _context.ParkingAreas.Where(x => x.ID == id).FirstOrDefault();
            if(found != null)
            {
                result.ID = found.ID;
                result.StreetAddress = found.StreetAddress;
                result.City = found.City;
                result.ZipCode = found.ZipCode;
                result.Latitude = found.Latitude;
                result.Longitude = found.Longitude;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public int ParkingSpaces(int id)
        {
            int noOfSpaces = 0;

            var found = _context.ParkingAreas.Where(x => x.ID == id).FirstOrDefault();

            var allSpaces = _context.ParkingSpaces.Include(x => x.ParkingArea).ToList();

            if (found != null)
            {
                allSpaces.ForEach(x =>
                {
                    if (x.ParkingArea.ID == id)
                    { noOfSpaces++; }
                });
            }
            else
            {
                return -1;
            }

            return noOfSpaces;
        }

        public bool UpdateParkingArea(ParkingAreaModel parkingAreaModel, int id)
        {
            var found = _context.ParkingAreas.Where(x => x.ID == id).FirstOrDefault();

            if (found != null)
            {
                found.ID = parkingAreaModel.ID;
                found.StreetAddress = parkingAreaModel.StreetAddress;
                found.City = parkingAreaModel.City;
                found.ZipCode = parkingAreaModel.ZipCode;
                found.Latitude = parkingAreaModel.Latitude;
                found.Longitude = parkingAreaModel.Longitude;
                _context.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
