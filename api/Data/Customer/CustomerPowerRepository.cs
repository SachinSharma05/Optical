using api.Abstraction.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Customer
{
    public class CustomerPowerRepository : ICustomerPowerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerPowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePowerDetails(PowerDetails powerDetails)
        {
            try
            {
                var powerDetail = new PowerDetails
                {
                    RSph = powerDetails.RSph,
                    RCyl = powerDetails.RCyl,
                    RAxis = powerDetails.RAxis,
                    RVn = powerDetails.RVn,
                    RAdd = powerDetails.RAdd,
                    LSph = powerDetails.LSph,
                    LCyl = powerDetails.LCyl,
                    LAxis = powerDetails.LAxis,
                    LVn = powerDetails.LVn,
                    LAdd = powerDetails.LAdd,
                    PD = powerDetails.PD,
                    RefBy = powerDetails.RefBy,
                    LensType1 = powerDetails.LensType1,
                    LensType2 = powerDetails.LensType2,
                    LensType3 = powerDetails.LensType3,
                    LensType4 = powerDetails.LensType4,
                    CheckUpDate = powerDetails.CheckUpDate,
                    Remarks = powerDetails.Remarks,
                    PrgRight = powerDetails.PrgRight,
                    PrgLeft = powerDetails.PrgLeft,
                    PPLeft = powerDetails.PPLeft,
                    PPRight = powerDetails.PPRight,
                    PPAdd = powerDetails.PPAdd
                };

                _context.PowerDetails.Add(powerDetails);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeletePowerDetail(int id)
        {
            try
            {
                var result = await _context.PowerDetails.Where(x => x.Id == id).FirstOrDefaultAsync();

                _context.PowerDetails.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PowerDetails> PowerDetailById(int id)
        {
            try
            {
                var result = await _context.PowerDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PowerDetails>> PowerDetailsList()
        {
            try
            {
                var result = await _context.PowerDetails.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePowerDetails(PowerDetails powerDetails)
        {
            try
            {
                var powerDetail = new PowerDetails
                {
                    RSph = powerDetails.RSph,
                    RCyl = powerDetails.RCyl,
                    RAxis = powerDetails.RAxis,
                    RVn = powerDetails.RVn,
                    RAdd = powerDetails.RAdd,
                    LSph = powerDetails.LSph,
                    LCyl = powerDetails.LCyl,
                    LAxis = powerDetails.LAxis,
                    LVn = powerDetails.LVn,
                    LAdd = powerDetails.LAdd,
                    PD = powerDetails.PD,
                    RefBy = powerDetails.RefBy,
                    LensType1 = powerDetails.LensType1,
                    LensType2 = powerDetails.LensType2,
                    LensType3 = powerDetails.LensType3,
                    LensType4 = powerDetails.LensType4,
                    CheckUpDate = powerDetails.CheckUpDate,
                    Remarks = powerDetails.Remarks,
                    PrgRight = powerDetails.PrgRight,
                    PrgLeft = powerDetails.PrgLeft,
                    PPLeft = powerDetails.PPLeft,
                    PPRight = powerDetails.PPRight,
                    PPAdd = powerDetails.PPAdd
                };

                _context.PowerDetails.Update(powerDetails);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
