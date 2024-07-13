
using IS3IncomabWebApi.DomainLayer.StaticClass.Record;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StaticClassController : ControllerBase
    {

        [HttpGet(Name = "ListStatus")]
        public IActionResult GetListStatus()
        {
            return Ok(Status.ListStatus);
        }

        [HttpGet(Name = "ListTypeCylinders")]
        public IActionResult GetListTypetCylinders()
        {
            return Ok(TypeCylinder.ListTypeCylinders);
        }
    }
}