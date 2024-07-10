using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface IOrder
    {
        public Task<ResponseDTO> GetOrder();
        public Task<ResponseDTO> AddOrder(OrderDTO orderDTO);
        public Task<ResponseDTO> UpdateOrder(OrderDTO orderDTO);
        public Task<ResponseDTO> DeleteOrder(int id);
    }
}
