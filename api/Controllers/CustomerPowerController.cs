using api.Abstraction.Services;
using api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPowerController : ControllerBase
    {
        private readonly ICustomerPowerService _customerPowerService;

        public CustomerPowerController(ICustomerPowerService customerPowerService)
        {
            _customerPowerService = customerPowerService;
        }

        [HttpGet("PowerDetailsList")]
        public async Task<IActionResult> PowerDetailsList()
        {
            var result = await _customerPowerService.PowerDetailsList();
            return Ok(result);
        }

        [HttpGet("PowerDetailById")]
        public async Task<IActionResult> PowerDetailById(int id)
        {
            var result = await _customerPowerService.PowerDetailById(id);
            return Ok(result);
        }

        [HttpPost("CreatePowerDetails")]
        public async Task<IActionResult> CreatePowerDetails(PowerDetails create)
        {
            var result = await _customerPowerService.CreatePowerDetails(create);
            return Ok(result);
        }

        [HttpPut("UpdatePowerDetails")]
        public async Task<IActionResult> UpdatePowerDetails(PowerDetails update)
        {
            var result = await _customerPowerService.UpdatePowerDetails(update);
            return Ok(result);
        }

        [HttpPost("DeletePowerDetail")]
        public async Task<IActionResult> DeletePowerDetail(int id)
        {
            var result = await _customerPowerService.DeletePowerDetail(id);
            return Ok(result);
        }
    }
}
