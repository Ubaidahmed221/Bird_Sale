using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder Service;
        public OrderController(IOrder service)
        {
            this.Service = service;
        }

        [HttpGet("GetCustomer")]
        public async Task<string> GetCustomer()
        {
            return JsonConvert.SerializeObject(await Service.GetOrder());
        }


        [HttpPost("AddOrder")]
        public async Task<string> AddOrder(OrderDTO orderDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddOrder(orderDTO));
        }


        [HttpPost("UpdateOrder")]
        public async Task<string> UpdateOrder(OrderDTO orderDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateOrder(orderDTO));
        }


        [HttpGet("DeleteOrder/{Id}")]
        public async Task<string> DeleteOrder(int Id)
        {
            return JsonConvert.SerializeObject(await Service.DeleteOrder(Id));
        }



    }
}
