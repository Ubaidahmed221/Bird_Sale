using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly IBird Service;
        public BirdController(IBird bird)
        {
            this.Service = bird;
        }   

        [HttpGet("GetBird")]
        public async Task<string> GetBird()
        {
            return JsonConvert.SerializeObject(await this.Service.GetBird());
        }

        [HttpPost("AddBird")]
        public async Task<string> AddBird([FromForm]BirdDTO birdDTO)
        {
            return JsonConvert.SerializeObject(await this.Service.AddBird(birdDTO));
        }

        [HttpPost("UpdateBird")]
        public async Task<string> UpdateBird([FromForm]BirdDTO birdDTO)
        {
            return JsonConvert.SerializeObject(await this.Service.UpdateBird(birdDTO));
        }

        [HttpGet("DeleteBird/{Id}")]
        public async Task<string> DeleteBird(int Id)
        {
            return JsonConvert.SerializeObject(await this.Service.DeleteBird(Id));
        }

    }
}
