using api.Abstraction.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Data.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCustomer(CustomerMaster customer)
        {
            try
            {
                var customers = new CustomerMaster
                {
                    customerName = customer.customerName,
                    address = customer.address,
                    contactNo = customer.contactNo,
                    alternateContact = customer.alternateContact,
                    age = customer.age,
                    gender = customer.gender,
                    email = customer.email,
                    remarks = customer.remarks
                };

                _context.CustomerMaster.Add(customers);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                var result = await _context.CustomerMaster.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.CustomerMaster.Remove(result);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedResponse<CustomerMaster>> GetCustomers(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var paginatedData = await _context.CustomerMaster.Skip(skip).Take(pageSize).ToListAsync();

                int totalItems = await _context.CustomerMaster.CountAsync();

                var response = new PaginatedResponse<CustomerMaster>
                {
                    Items = paginatedData.Select(item => new CustomerMaster
                    {
                        Id = item.Id,
                        customerName = item.customerName,
                        address = item.address,
                        contactNo = item.contactNo,
                        alternateContact = item.alternateContact,
                        age = item.age,
                        gender = item.gender,
                        email = item.email,
                        remarks = item.remarks
                    }).ToList(),
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

        public async Task<bool> UpdateCustomer(CustomerMaster customer)
        {
            var existingCustomer = await _context.CustomerMaster
            .Where(x => x.Id == customer.Id)
            .FirstOrDefaultAsync();

            if (existingCustomer == null)
            {
                return false;
            }

            try
            {
                existingCustomer.customerName = customer.customerName;
                existingCustomer.address = customer.address;
                existingCustomer.contactNo = customer.contactNo;
                existingCustomer.alternateContact = customer.alternateContact;
                existingCustomer.age = customer.age;
                existingCustomer.gender = customer.gender;
                existingCustomer.email = customer.email;
                existingCustomer.remarks = customer.remarks;

                _context.CustomerMaster.Update(existingCustomer);
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
