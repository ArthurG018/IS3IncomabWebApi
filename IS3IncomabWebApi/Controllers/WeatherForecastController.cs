
using IS3IncomabWebApi.DomainLayer.StaticClass.Record;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        
        /**
         
         PRUEBA
         
         */
        /*[HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var listaStatus = new List<String>();
            foreach (var status in Enum.GetValues(typeof(Status)))
            {
                listaStatus.Add(status.ToString() ?? "");
            }
         
            return Ok(listaStatus);
        }*/

        [HttpGet(Name = "Lista")]
        public IActionResult GetList()
        {
            return Ok(Status.ListStatus);
        }
        [HttpGet(Name = "ListaType")]
        public IActionResult GetTypet()
        {
            return Ok(TypeCylinder.ListTypeCylinders);
        }
    }
}