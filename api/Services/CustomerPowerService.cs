using api.Abstraction.Data;
using api.Abstraction.Services;
using api.Entities;
using Newtonsoft.Json.Linq;

namespace api.Services
{
    public class CustomerPowerService : ICustomerPowerService
    {
        private readonly ICustomerPowerRepository _customerPowerRepository;

        public CustomerPowerService(ICustomerPowerRepository customerPowerRespository)
        {
            _customerPowerRepository = customerPowerRespository;   
        }

        public async Task<bool> CreatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetails)
        {
            return await _customerPowerRepository.CreatePowerDetails(customerDTO, powerDetails);
        }

        public async Task<bool> DeletePowerDetail(int id)
        {
            return await _customerPowerRepository.DeletePowerDetail(id);
        }

        public async Task<PaginatedResponse<PowerDetailsList>> PowerDetailsList(int page, int pageSize)
        {
            return await _customerPowerRepository.PowerDetailsList(page, pageSize);
        }

        public async Task<bool> UpdatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetailsDTO)
        {
            return await _customerPowerRepository.UpdatePowerDetails(customerDTO, powerDetailsDTO);
        }
    }
}
