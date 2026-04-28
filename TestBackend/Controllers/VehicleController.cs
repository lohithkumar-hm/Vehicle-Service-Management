using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBackend.DTOs;
using TestBackend.Model.Repository.Abstraction;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVRepository repo) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<VehicleDTO>> GetAllVehicles()
        {
            try
            {
                var all = repo.GetAllVehicles();
                if (all?.Count() > 0)
                    return Ok(all);
                else
                    return Ok(new List<VehicleDTO>());
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }


        [HttpGet]
        [Route("{number}")]
        public ActionResult<VehicleDTO> GetAVehicle([FromRoute] string number)
        {
            try
            {
                var data = repo.GetVehicle(number);
                if (data != null)
                    return Ok(data);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }



        [HttpPost]
        [Route("add")]
        public ActionResult<VehicleDTO> AddVehicle([FromBody] VehicleDTO data)
        {
            try
            {
                var added = repo.AddVehicle(data);
                return CreatedAtAction(nameof(AddVehicle), added);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message, statusCode: 500);
            }
        }



        [HttpPut]
        [Route("edit/{number}")]
        public ActionResult<VehicleDTO> UpdateVehicle([FromRoute] string number, [FromBody] VehicleDTO data)
        {
            try
            {
                var edited = repo.UpdateVehicle(number, data);
                return CreatedAtAction(nameof(UpdateVehicle), edited);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }


        [HttpDelete]
        [Route("delete/{number}")]
        public ActionResult<VehicleDTO> DeleteVehicle([FromRoute] string number)
        {
            try
            {
                var deleted = repo.DeleteVehicle(number);
                return Ok(deleted);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

    }
}
