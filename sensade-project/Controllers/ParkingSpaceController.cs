using Microsoft.AspNetCore.Mvc;
using sensade_project.BusinessLayer;
using sensade_project.EfCore;
using sensade_project.ModelLayer;

namespace sensade_project.Controllers
{
    [ApiController]
    public class ParkingSpaceController : Controller
    {
        IParkingSpaceBusiness parkingBusiness;

        public ParkingSpaceController(DataContext dataContext)
        {
            parkingBusiness = new ParkingSpaceBusiness(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<List<ParkingSpaceModel>> Get()
        {
            ActionResult<List<ParkingSpaceModel>> foundReturn;
            List<ParkingSpaceModel>? foundSpaces = parkingBusiness.GetAllSpaces();
            if (foundSpaces != null)
            {
                if (foundSpaces.Count > 0)
                {
                    foundReturn = Ok(foundSpaces);
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
        public ActionResult<ParkingSpaceModel> Get(int id)
        {
            ActionResult<ParkingSpaceModel> foundReturn;
            ParkingSpaceModel? foundSpace = parkingBusiness.GetParkingSpace(id);
            if (foundSpace != null)
            {
                foundReturn = Ok(foundSpace);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

        [HttpPost]
        [Route("api/[controller]/{areaId}")]
        public ActionResult Post(ParkingSpaceModel parkingSpaceModel, int areaId)
        {
            ActionResult foundReturn;
            if (parkingBusiness.CreateParkingSpace(parkingSpaceModel, areaId))
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
        [Route("api/[controller]/{id}/{areaId}")]
        public ActionResult Put(ParkingSpaceModel parkingSpaceModel, int id, int areaId)
        {
            ActionResult foundReturn;
            if (parkingBusiness.UpdateParkingSpace(parkingSpaceModel, id, areaId))
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
            if (parkingBusiness.DeleteParkingSpace(id))
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
        [Route("api/[controller]/status/{id}/{status}")]
        public ActionResult SetStatus(int id, string status)
        {
            ActionResult foundReturn;
            if (status == "free" || status == "occupied")
            {
                if(parkingBusiness.setStatus(id, status))
                {
                    foundReturn = new StatusCodeResult(200);
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);
                }
                
            }
            else
            {
                foundReturn = new StatusCodeResult(400);
            }
            return foundReturn;
        }
    }
}
