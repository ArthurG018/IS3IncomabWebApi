using IS3IncomabWebApi.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        private readonly IReportMain _reportMain;

        public ReportController(IReportMain reportMain)
        {
            _reportMain = reportMain;
        }

        [HttpGet(Name = "GetReportUbicationCylinderR01")]
        public IActionResult GetReportUbicationCylinderR01()
        {
            var response = _reportMain.GetReport01();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportRecorridoCilindroR02")]
        public IActionResult GetReportRecorridoCilindroR02()
        {
            var response = _reportMain.GetReport02();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportCilindroGarantiaR03")]
        public IActionResult GetReportCilindroGarantiaR03()
        {
            var response = _reportMain.GetReport03();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportClienteHistorialCilindroR04")]
        public IActionResult GetReportClienteHistorialCilindroR04()
        {
            var response = _reportMain.GetReport04();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportPorClienteHistorialCilindroR05")]
        public IActionResult GetReportPorClienteHistorialCilindroR05(int customerId)
        {
            var response = _reportMain.GetReport05(customerId);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportVentaMesR06")]
        public IActionResult GetReportVentaMesR06()
        {
            var response = _reportMain.GetReport06();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportVentaTipoCilindroR07")]
        public IActionResult GetReportVentaTipoCilindroR07()
        {
            var response = _reportMain.GetReport07();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(Name = "GetReportM3ClienteMensualR08")]
        public IActionResult GetReportM3ClienteMensualR08()
        {
            var response = _reportMain.GetReport08();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }
    }
}
