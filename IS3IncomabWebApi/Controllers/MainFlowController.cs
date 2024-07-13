using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IS3IncomabWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainFlowController : Controller
    {
        private readonly IMainFlowDto _mainFlowDto;

        public MainFlowController(IMainFlowDto mainFlowDto)
        {
            _mainFlowDto = mainFlowDto;
        }

        [HttpPost]
        [ActionName("MainFlow")]
        public IActionResult PostMainFlow([FromBody] ActionGeneralDto actionGeneralDto)
        {
            var response = _mainFlowDto.ActionGeneral(actionGeneralDto.sourceMainDTO, actionGeneralDto.actionListDTOsDG, actionGeneralDto.actionListDTOsSale, actionGeneralDto.actionListDTOsWarranty);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
