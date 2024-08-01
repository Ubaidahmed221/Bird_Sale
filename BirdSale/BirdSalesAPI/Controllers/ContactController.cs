using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BirdSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact Service;
        public ContactController(IContact contact)
        {
            this.Service = contact;
        }



        [HttpGet("GetContact")]
        public async Task<string> GetContact()
        {
            return JsonConvert.SerializeObject(await Service.GetContact());
        }

        [HttpPost("AddContact")]
        public async Task<string> AddContact(ContactDTO contactDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddContact(contactDTO));
        }

        [HttpPost("UpdateContact")]
        public async Task<string> UpdateContact(ContactDTO contactDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateContact(contactDTO));
        }


        [HttpGet("DeleteContact/{id}")]
        public async Task<string> DeleteContact(int id)
        {
            return JsonConvert.SerializeObject(await Service.DeleteContact(id));
        }

    }
}
