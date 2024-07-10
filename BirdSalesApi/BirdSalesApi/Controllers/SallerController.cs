using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SallerController : ControllerBase
    {
        private readonly ISaller Service;
        public SallerController(ISaller service)
        {
            this.Service = service;
        }

        [HttpGet("GetSaller")]
        public async Task<string> GetSaller()
        {
            return JsonConvert.SerializeObject(await Service.GetSaller());
        }

        [HttpPost("AddSaller")]
        public async Task<string> AddSaller(SallerDTO sallerDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddSaller(sallerDTO));
        }

        [HttpPost("UpdateSaller")]
        public async Task<string> UpdateSaller(SallerDTO sallerDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateSaller(sallerDTO));
        }

        [HttpGet("DeleteSaller/{Id}")]
        public async Task<string> DeleteSaller(int Id)
        {
            return JsonConvert.SerializeObject(await Service.DeleteSaller(Id));
        }

    }
}
