using IS3IncomabWebApi.ApplicationLayer.Interface;
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

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var response = _cylinderMain.GetAll();
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}
