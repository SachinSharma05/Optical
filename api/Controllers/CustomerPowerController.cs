using api.Abstraction.Services;
using api.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

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
        public async Task<IActionResult> PowerDetailsList(int page, int pageSize)
        {
            var result = await _customerPowerService.PowerDetailsList(page, pageSize);
            return Ok(result);
        }

        [HttpPost("CreatePowerDetails")]
        public async Task<IActionResult> CreatePowerDetails([FromBody] CreatePowerRequest payload)
        {
            try
            {
                // Parse the payload into respective DTOs
                var customerDetails = payload.CustomerDetails;
                var powerDetails = payload.PowerDetails;

                // Process and save data
                var result = await _customerPowerService.CreatePowerDetails(customerDetails, powerDetails);

                if (result)
                {
                    return Ok(new { message = "Data saved successfully." });
                }

                return BadRequest(new { message = "Failed to save data." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        [HttpPut("UpdatePowerDetails")]
        public async Task<IActionResult> UpdatePowerDetails([FromBody] CreatePowerRequest payload)
        {
            try
            {
                var customerDetails = payload.CustomerDetails;
                var powerDetails = payload.PowerDetails;

                var result = await _customerPowerService.UpdatePowerDetails(customerDetails, powerDetails);
                if (result)
                {
                    return Ok(new { message = "Data updated successfully." });
                }

                return BadRequest(new { message = "Failed to save data." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        [HttpDelete("DeletePowerDetail")]
        public async Task<IActionResult> DeletePowerDetail(int id)
        {
            var result = await _customerPowerService.DeletePowerDetail(id);
            return Ok(result);
        }
    }
}
