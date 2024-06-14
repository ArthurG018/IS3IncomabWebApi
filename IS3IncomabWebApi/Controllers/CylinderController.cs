using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CylinderController : Controller
    {
        private readonly ICylinderDto _cylinderMain;

        public CylinderController(ICylinderDto cylinderMain)
        {
            _cylinderMain = cylinderMain;
        }

        [HttpPost]
        [ActionName("GetAll")]
        public IActionResult GetAll(PaginationFilter paginationFilter)
        {
            var response = _cylinderMain.GetAll(paginationFilter.StartIndex, paginationFilter.MaxRecord, paginationFilter.filter);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}
