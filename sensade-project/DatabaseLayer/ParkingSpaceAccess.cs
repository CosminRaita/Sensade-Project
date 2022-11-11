using Microsoft.EntityFrameworkCore;
using sensade_project.EfCore;
using sensade_project.ModelLayer;

namespace sensade_project.DatabaseLayer
{
    public class ParkingSpaceAccess : IParkingSpaceAccess
    {
        private DataContext _context;

        public ParkingSpaceAccess(DataContext context)
        {
            _context = context;
        }

        public bool CreateParkingSpace(ParkingSpaceModel parkingSpaceModel, int parkingAreaId)
        {
            ParkingSpace parkingSpace = new ParkingSpace();
            ParkingArea parkingArea = _context.ParkingAreas.Where(x => x.ID == parkingAreaId).First();
            if (parkingSpaceModel != null)
            {
                if(parkingArea != null)
                {
                    parkingSpace.ID = parkingSpaceModel.ID;
                    parkingSpace.Status = parkingSpaceModel.Status;
                    parkingSpace.SpaceNumber = parkingSpaceModel.SpaceNumber;
                    parkingSpace.ParkingArea = parkingArea;
                    _context.ParkingSpaces.Add(parkingSpace);
                    _context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteParkingSpace(int id)
        {
            ParkingSpace parkingSpace = _context.ParkingSpaces.Where(x => x.ID == id).FirstOrDefault();
            if (parkingSpace != null)
            {
                _context.ParkingSpaces.Remove(parkingSpace);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public List<ParkingSpaceModel>? GetAllSpaces()
        {
            List<ParkingSpaceModel> result = new List<ParkingSpaceModel>();

            var parkingSpaces = _context.ParkingSpaces.Include(x => x.ParkingArea).ToList();

            parkingSpaces.ForEach(row => result.Add(new ParkingSpaceModel()
            {
                ID = row.ID,
                Status = row.Status,
                SpaceNumber = row.SpaceNumber,
                ParkingAreaID = row.ParkingArea.ID
            })) ;

            return result;
        }

        public ParkingSpaceModel? GetParkingSpace(int id)
        {
            ParkingSpaceModel result = new ParkingSpaceModel();

            var found = _context.ParkingSpaces.Include(x => x.ParkingArea).Where(x => x.ID == id).FirstOrDefault();

            if (found != null)
            {
                result.ID = found.ID;
                result.Status = found.Status;
                result.SpaceNumber = found.SpaceNumber;
                result.ParkingAreaID = found.ParkingArea.ID;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public bool setStatus(int id, string status)
        {
            bool result = true;

            var found = _context.ParkingSpaces.Where(x => x.ID == id).FirstOrDefault();

            if (found != null)
            {
                found.Status = status;
                _context.SaveChanges();
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool UpdateParkingSpace(ParkingSpaceModel parkingSpaceModel, int id, int parkingAreaId)
        {
            var found = _context.ParkingSpaces.Where(x => x.ID == id).FirstOrDefault();
            ParkingArea parkingArea = _context.ParkingAreas.Where(x => x.ID == parkingAreaId).First();
            if (parkingSpaceModel != null)
            {
                if (parkingArea != null)
                {
                    found.ID = parkingSpaceModel.ID;
                    found.Status = parkingSpaceModel.Status;
                    found.SpaceNumber = parkingSpaceModel.SpaceNumber;
                    found.ParkingArea = parkingArea;
                    _context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
