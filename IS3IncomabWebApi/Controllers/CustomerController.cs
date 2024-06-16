using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.ApplicationLayer.Main;
using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;
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

        [HttpPost]
        [ActionName("GetAll")]
        public IActionResult GetAll(PaginationFilter paginationFilter)
        {
            var response = _customerMain.GetAll(paginationFilter.StartIndex, paginationFilter.MaxRecord, paginationFilter.filter);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut]
        [ActionName("Update")]
        public IActionResult Update(CustomerDto customerDto)
        {
            var response = _customerMain.Update(customerDto);
            if (response.Data) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpPut]
        [ActionName("DeleteLogic")]
        public IActionResult DeleteLogic(int customerId, int userId)
        {
            var response = _customerMain.DeleteLogic(customerId, userId);
            if (response.Data) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}
