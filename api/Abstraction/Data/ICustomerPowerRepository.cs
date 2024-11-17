using api.Entities;
using Newtonsoft.Json.Linq;

namespace api.Abstraction.Data
{
    public interface ICustomerPowerRepository
    {
        Task<PaginatedResponse<PowerDetailsList>> PowerDetailsList(int page, int pageSize);
        Task<bool> CreatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetails);
        Task<bool> UpdatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetailsDTO);
        Task<bool> DeletePowerDetail(int id);
    }
}
