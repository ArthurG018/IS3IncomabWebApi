using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.ApplicationLayer.Main;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerDto _customerMain;
        public CustomerController(ICustomerDto customerMain)
        {
            _customerMain = customerMain;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll(int startIndex, int MaxRecord)
        {
            var response = _customerMain.GetAll(startIndex, MaxRecord);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}
