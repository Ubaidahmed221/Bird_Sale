using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer Service;
        public CustomerController(ICustomer service)
        {
            this.Service = service;
        }

        [HttpGet("GetCustomer")]
        public async Task<string> GetCustomer()
        {
            return JsonConvert.SerializeObject(await Service.GetCustomer());
        }


        [HttpPost("AddCustomer")]
        public async Task<string> AddCustomer(CustomerDTO customerDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddCustomer(customerDTO));
        }


        [HttpPost("UpdateCustomer")]
        public async Task<string> UpdateCustomer(CustomerDTO customerDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateCustomer(customerDTO));
        }


        [HttpGet("DeleteCustomer/{Id}")]
        public async Task<string> DeleteCustomer(int Id)
        {
            return JsonConvert.SerializeObject(await Service.DeleteCustomer(Id));
        }




    }
}
