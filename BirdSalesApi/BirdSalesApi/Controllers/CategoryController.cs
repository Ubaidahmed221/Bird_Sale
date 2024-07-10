using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdSalesAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly ICategory Service;
        public CategoryController(ICategory category)
        {
            this.Service = category;
        }

        [HttpGet("GetCategory")]
      public async Task<string> GetCategory()

        {
            return JsonConvert.SerializeObject(await Service.GetCategory());
        }




        [HttpPost("AddCategory")]
        public async Task<string> AddCategory(CategoryDTO categoryDTO)
        {
           return JsonConvert.SerializeObject(await Service.AddCategory(categoryDTO));
        }

        [HttpPost("UpdateCategory")]
        public async Task<string> UpdateCategory(CategoryDTO categoryDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateCategory(categoryDTO));
        }

        [HttpGet("DeleteCategory/{id}")]
        public async Task<string> DeleteCategory(int id)
        {
          return JsonConvert.SerializeObject(await Service.DeleteCategory(id));
        }




    }
}
