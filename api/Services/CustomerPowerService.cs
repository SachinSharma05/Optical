using api.Abstraction.Data;
using api.Abstraction.Services;
using api.Entities;

namespace api.Services
{
    public class CustomerPowerService : ICustomerPowerService
    {
        private readonly ICustomerPowerRepository _customerPowerRepository;

        public CustomerPowerService(ICustomerPowerRepository customerPowerRespository)
        {
            _customerPowerRepository = customerPowerRespository;   
        }

        public async Task<bool> CreatePowerDetails(PowerDetails powerDetails)
        {
            return await _customerPowerRepository.CreatePowerDetails(powerDetails);
        }

        public async Task<bool> DeletePowerDetail(int id)
        {
            return await _customerPowerRepository.DeletePowerDetail(id);
        }

        public async Task<PowerDetails> PowerDetailById(int id)
        {
            return await _customerPowerRepository.PowerDetailById(id);
        }

        public async Task<IEnumerable<PowerDetails>> PowerDetailsList()
        {
            return await _customerPowerRepository.PowerDetailsList();
        }

        public async Task<bool> UpdatePowerDetails(PowerDetails powerDetails)
        {
            return await _customerPowerRepository.UpdatePowerDetails(powerDetails);
        }
    }
}
