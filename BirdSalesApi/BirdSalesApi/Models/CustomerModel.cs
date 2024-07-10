using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class CustomerModel :ICustomer
    {
         private readonly ApplicationDbContext DbContext;
      
        public CustomerModel( ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext; 
        }
        public async Task<ResponseDTO> GetCustomer()
        {
            var ResponseDTO = new ResponseDTO();
            try {
                ResponseDTO.Response = await DbContext.Customers.ToListAsync();
            }

                catch (Exception ex) {
            ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;

        }
        public async Task<ResponseDTO> AddCustomer(CustomerDTO CustomerDTO)
        {var ResponseDTO = new ResponseDTO();
            try
            {
                if (CustomerDTO != null)
                {
                    var Customer = new Customer()
                    {
                        Name = CustomerDTO.Name,
                        Email = CustomerDTO.Email,
                        Address = CustomerDTO.Address,
                        Number = CustomerDTO.Number,
                    };
                    await DbContext.Customers.AddAsync(Customer);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Customer Add Successfully";
                    ResponseDTO.StatusCode = 200;

                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }

            return ResponseDTO;
        }
        public async Task<ResponseDTO> UpdateCustomer(CustomerDTO CustomerDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                if(CustomerDTO != null)
                {
                var Customer = new Customer()
                {
                    PkId = CustomerDTO.PkId,
                    Name = CustomerDTO.Name,
                    Email = CustomerDTO.Email,
                    Number = CustomerDTO.Number,
                    Address = CustomerDTO.Address,
                };
                    DbContext.Customers.Update(Customer);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Customer Update Successfully";
                    ResponseDTO.StatusCode = 200;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }

            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
        public async Task<ResponseDTO> DeleteCustomer(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Customers.Where(x => x.PkId == Id).FirstOrDefaultAsync();
                if(Data != null)
                {
                    DbContext.Customers.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.StatusCode = 200;
                    ResponseDTO.Response = "Customer Deleted Successfully";
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
    }
}
