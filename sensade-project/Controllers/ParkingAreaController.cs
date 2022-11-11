using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sensade_project.BusinessLayer;
using sensade_project.DatabaseLayer;
using sensade_project.EfCore;
using sensade_project.ModelLayer;
using System;

namespace sensade_project.Controllers
{
    [ApiController]
    public class ParkingAreaController : Controller
    {
        IParkingAreaBusiness parkingBusiness;

        public ParkingAreaController(DataContext dataContext)
        {
            parkingBusiness = new ParkingAreaBusiness(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<List<ParkingAreaModel>> GetAll()
        {
            ActionResult<List<ParkingAreaModel>> foundReturn;
            List<ParkingAreaModel>? foundAreas = parkingBusiness.GetAllAreas();
            if (foundAreas != null)
            {
                if (foundAreas.Count > 0)
                {
                    foundReturn = Ok(foundAreas);
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<ParkingAreaModel> Get(int id)
        {
            ActionResult<ParkingAreaModel> foundReturn;
            ParkingAreaModel? foundArea = parkingBusiness.GetParkingArea(id);
            if (foundArea != null)
            {
                foundReturn = Ok(foundArea);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult Post(ParkingAreaModel parkingAreaModel)
        {
            ActionResult foundReturn;
            if(parkingBusiness.CreateParkingArea(parkingAreaModel))
            {
                foundReturn = new StatusCodeResult(200);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public ActionResult Put(ParkingAreaModel parkingAreaModel, int id)
        {
            ActionResult foundReturn;
            if (parkingBusiness.UpdateParkingArea(parkingAreaModel, id))
            {
                foundReturn = new StatusCodeResult(200);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult Delete(int id)
        {
            ActionResult foundReturn;
            if (parkingBusiness.DeleteParkingArea(id))
            {
                foundReturn = new StatusCodeResult(200);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpGet]
        [Route("api/[controller]/spaces/{id}")]
        public ActionResult ParkingSpaces(int id)
        {
            ActionResult foundReturn;
            int noOfSpaces = parkingBusiness.ParkingSpaces(id);
            if (noOfSpaces != -1)
            {
                foundReturn = Ok(noOfSpaces);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpGet]
        [Route("api/[controller]/freeSpaces/{id}")]
        public ActionResult AvailableParkingSpaces(int id)
        {
            ActionResult foundReturn;
            int noOfSpaces = parkingBusiness.AvailableParkingSpaces(id);
            if (noOfSpaces != -1)
            {
                foundReturn = Ok(noOfSpaces);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }
    }
}
