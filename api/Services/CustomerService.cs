using api.Abstraction.Data;
using api.Abstraction.Services;
using api.Entities;

namespace api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateCustomer(CustomerMaster customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }

        public async Task<PaginatedResponse<CustomerMaster>> GetCustomers(int page, int pageSize)
        {
            return await _customerRepository.GetCustomers(page, pageSize);
        }

        public async Task<bool> UpdateCustomer(CustomerMaster customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }
    }
}
