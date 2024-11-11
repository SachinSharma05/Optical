using api.Entities;

namespace api.Abstraction.Data
{
    public interface ICustomerRepository
    {
        Task<PaginatedResponse<CustomerMaster>> GetCustomers(int page, int pageSize);
        Task<bool> CreateCustomer(CustomerMaster customer);
        Task<bool> UpdateCustomer(CustomerMaster customer);
        Task<bool> DeleteCustomer(int id);
    }
}
