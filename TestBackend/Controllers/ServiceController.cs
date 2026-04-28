using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBackend.DTOs;
using TestBackend.Model.Repository.Abstraction;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(ISRepository repo) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<ServiceDTO>> GetAllServices()
        {
            try
            {
                var all = repo.GetAllServices();
                if (all?.Count() > 0)
                    return Ok(all);
                else
                    return Ok(new List<ServiceDTO>());
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ServiceDTO> GetAService([FromRoute] int id)
        {
            try
            {
                var data = repo.GetService(id);
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
        public ActionResult<ServiceDTO> AddService([FromBody] ServiceDTO data)
        {
            try
            {
                var added = repo.AddService(data);
                return CreatedAtAction(nameof(AddService), added);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message, statusCode: 500);
            }
        }



        [HttpPut]
        [Route("edit/{id}")]
        public ActionResult<ServiceDTO> UpdateService([FromRoute] int id, [FromBody] ServiceDTO data)
        {
            try
            {
                var edited = repo.UpdateService(id, data);
                return CreatedAtAction(nameof(UpdateService), edited);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<ServiceDTO> DeleteService([FromRoute] int id)
        {
            try
            {
                var deleted = repo.DeleteService(id);
                return Ok(deleted);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("report")]
        public ActionResult<ServiceReportDTO> GetServiceReport()
        {
            var data = repo.GetServiceReport();
            return Ok(data);
        }
    }
}
