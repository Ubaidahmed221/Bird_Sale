using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface ICustomer
    {

        public Task<ResponseDTO> GetCustomer();
        public Task<ResponseDTO> AddCustomer(CustomerDTO CustomerDTO);
        public Task<ResponseDTO> UpdateCustomer(CustomerDTO CustomerDTO);
        public Task<ResponseDTO> DeleteCustomer(int Id);

    }
}
