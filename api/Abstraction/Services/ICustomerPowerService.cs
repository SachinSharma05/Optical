using api.Entities;
using Newtonsoft.Json.Linq;

namespace api.Abstraction.Services
{
    public interface ICustomerPowerService
    {
        Task<PaginatedResponse<PowerDetailsList>> PowerDetailsList(int page, int pageSize);
        Task<bool> CreatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetailsDTO);
        Task<bool> UpdatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetailsDTO);
        Task<bool> DeletePowerDetail(int id);
    }
}
