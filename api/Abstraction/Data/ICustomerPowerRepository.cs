using api.Entities;

namespace api.Abstraction.Data
{
    public interface ICustomerPowerRepository
    {
        Task<IEnumerable<PowerDetails>> PowerDetailsList();
        Task<PowerDetails> PowerDetailById(int id);
        Task<bool> CreatePowerDetails(PowerDetails powerDetails);
        Task<bool> UpdatePowerDetails(PowerDetails powerDetails);
        Task<bool> DeletePowerDetail(int id);
    }
}
