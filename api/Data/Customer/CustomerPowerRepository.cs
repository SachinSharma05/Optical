using api.Abstraction.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api.Data.Customer
{
    public class CustomerPowerRepository : ICustomerPowerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerPowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePowerDetails(CustomerMaster customerDetails, PowerDetails powerDetails)
        {
            try
            {
                var customer = await _context.CustomerMaster.FirstOrDefaultAsync(x => x.contactNo == customerDetails.contactNo);

                if (customer == null)
                {
                    customer = new CustomerMaster
                    {
                        customerName = customerDetails.customerName,
                        address = customerDetails.address,
                        contactNo = customerDetails.contactNo,
                        alternateContact = customerDetails.alternateContact,
                        age = customerDetails.age,
                        gender = customerDetails.gender,
                        email = customerDetails.email,
                        remarks = customerDetails.remarks
                    };

                    _context.CustomerMaster.Add(customer);
                    await _context.SaveChangesAsync();

                    int newCustomerId = powerDetails.customerId;
                    Console.WriteLine($"New customer added with ID: {newCustomerId}");
                }
                else
                {
                    Console.WriteLine("Customer already exists, skipping save operation.");
                }

                var powerDetail = new PowerDetails
                {
                    customerId = customer != null ? customer.Id : powerDetails.customerId,
                    rsph = powerDetails.rsph,
                    rcyl = powerDetails.rcyl,
                    raxis = powerDetails.raxis,
                    rvn = powerDetails.rvn,
                    radd = powerDetails.radd,
                    lsph = powerDetails.lsph,
                    lcyl = powerDetails.lcyl,
                    laxis = powerDetails.laxis,
                    lvn = powerDetails.lvn,
                    ladd = powerDetails.ladd,
                    pd = powerDetails.pd,
                    refBy = powerDetails.refBy,
                    lensType = powerDetails.lensType,
                    bookingDate = powerDetails.bookingDate,
                    remarks = powerDetails.remarks,
                    prgRight = powerDetails.prgRight,
                    prgLeft = powerDetails.prgLeft,
                    ppLeft = powerDetails.ppLeft,
                    ppRight = powerDetails.ppRight,
                    ppAdd = powerDetails.ppAdd,
                    createdOn = DateTime.Now
                };

                _context.CustomerPower.Add(powerDetail);
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
                var result = await _context.CustomerPower.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(result != null)
                {
                    _context.CustomerPower.Remove(result);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedResponse<PowerDetailsList>> PowerDetailsList(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                int totalItems = await _context.CustomerPower.CountAsync();

                string query = $@"select cp.id, cp.customerId, cm.customerName, cm.contactNo, cm.alternateContact,
                                cp.rsph, cp.rcyl, cp.raxis, cp.rvn,
                                cp.lsph, cp.lcyl, cp.laxis, cp.lvn, cp.radd, cp.ladd,
                                cp.pd, cp.refBy, cp.lensType, cp.bookingDate, cp.prgRight, cp.prgLeft,
                                cp.ppRight, cp.ppLeft, cp.ppAdd, cp.remarks, cp.createdOn
                                from customerMaster cm
                                inner join customerPower cp on cm.id = cp.customerId";

                var result = await _context.CustomerPowerList.FromSqlRaw<PowerDetailsList>(query).ToListAsync();

                var response = new PaginatedResponse<PowerDetailsList>
                {
                    Items = result,
                    TotalItems = totalItems,
                    Page = page,
                    PageSize = pageSize
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePowerDetails(CustomerMaster customerDTO, PowerDetails powerDetails)
        {
            var existingCustomer = await _context.CustomerPower.Where(x => x.Id == powerDetails.Id).FirstOrDefaultAsync();

            if (existingCustomer == null)
            {
                return false;
            }

            try
            {
                existingCustomer.rsph = powerDetails.rsph;
                existingCustomer.rcyl = powerDetails.rcyl;
                existingCustomer.raxis = powerDetails.raxis;
                existingCustomer.rvn = powerDetails.rvn;
                existingCustomer.radd = powerDetails.radd;
                existingCustomer.lsph = powerDetails.lsph;
                existingCustomer.lcyl = powerDetails.lcyl;
                existingCustomer.laxis = powerDetails.laxis;
                existingCustomer.lvn = powerDetails.lvn;
                existingCustomer.ladd = powerDetails.ladd;
                existingCustomer.pd = powerDetails.pd;
                existingCustomer.refBy = powerDetails.refBy;
                existingCustomer.lensType = powerDetails.lensType;
                existingCustomer.bookingDate = powerDetails.bookingDate;
                existingCustomer.remarks = powerDetails.remarks;
                existingCustomer.prgRight = powerDetails.prgRight;
                existingCustomer.prgLeft = powerDetails.prgLeft;
                existingCustomer.ppLeft = powerDetails.ppLeft;
                existingCustomer.ppRight = powerDetails.ppRight;
                existingCustomer.ppAdd = powerDetails.ppAdd;

                _context.CustomerPower.Update(existingCustomer);
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
