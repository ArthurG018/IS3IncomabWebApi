using IS3IncomabWebApi.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserDto _userDto;

        public UserController(IUserDto userDto)
        {
            _userDto = userDto;
        }

        [HttpGet]
        [ActionName("GetUser")]
        public IActionResult GetUser(string user, string psw)
        {
            var response = _userDto.GetUser(user, psw);
            return Ok(response);
        }
    }
}
