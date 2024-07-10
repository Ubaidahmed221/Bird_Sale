using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class OrderModel : IOrder
    {
        private readonly ApplicationDbContext DbContext;
        public OrderModel(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public async Task<ResponseDTO> GetOrder()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await DbContext.Orders.ToListAsync();
            }

            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> AddOrder(OrderDTO orderDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                if (orderDTO != null)
                {
                    var Order = new Order()
                    {
                        FkCustomerId=orderDTO.FkCustomerId,
                        FkBirdId=orderDTO.FkBirdId,
                        OrderDate=orderDTO.OrderDate,
                        Quantity = orderDTO.Quantity,
                        TotelPrice = orderDTO.TotelPrice
                    };
                    await DbContext.Orders.AddAsync(Order);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Order Add Successfully";
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



        public async Task<ResponseDTO> UpdateOrder(OrderDTO orderDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                if (orderDTO != null)
                {
                    var Order = new Order()
                    {
                        PkId = orderDTO.PkId,
                        FkCustomerId = orderDTO.FkCustomerId,
                        FkBirdId = orderDTO.FkBirdId,
                        OrderDate = orderDTO.OrderDate,
                        Quantity = orderDTO.Quantity,
                        TotelPrice = orderDTO.TotelPrice
                    };
                    DbContext.Orders.Update(Order);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Order Update Successfully";
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

        public async Task<ResponseDTO> DeleteOrder(int id)
        {

            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Orders.Where(x => x.PkId == id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    DbContext.Orders.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.StatusCode = 200;
                    ResponseDTO.Response = "Order Deleted Successfully";
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

       

       
    }
}
