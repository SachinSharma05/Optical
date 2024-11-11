using api.Abstraction.Services;
using api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers(int page, int pageSize)
        {
            var result = await _customerService.GetCustomers(page, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerMaster create)
        {
            var result = await _customerService.CreateCustomer(create);
            return Ok(result);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerMaster update)
        {
            var result = await _customerService.UpdateCustomer(update);
            return Ok(result);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return Ok(result);
        }
    }
}
