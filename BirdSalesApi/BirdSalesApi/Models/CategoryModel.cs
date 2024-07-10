using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class CategoryModel : ICategory
    {

        private readonly ApplicationDbContext DbContext;
        public CategoryModel(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;   
        }
        public async Task<ResponseDTO> GetCategory()
        {
           var ResponseDTO = new ResponseDTO();
            try {
                ResponseDTO.Response = await DbContext.Category.ToListAsync();
            }
            catch (Exception ex)
            {
               ResponseDTO.ErrorMessage = ex.Message;   
            }
            return ResponseDTO;
        }
        public async Task<ResponseDTO> AddCategory(CategoryDTO CategoryDTO)
        {
            var ResponseDTO=new ResponseDTO();

            try
            {
                if (CategoryDTO != null)
                {
                    var Category = new Category()
                    {
                        Name = CategoryDTO.Name,
                        Description = CategoryDTO.Description
                    };

                    await DbContext.Category.AddAsync(Category);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Category Successfully Added";
                    ResponseDTO.StatusCode= 200;
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
        public async Task<ResponseDTO> UpdateCategory(CategoryDTO CategoryDTO)
        {
            var ResponseDTO=new ResponseDTO();
            try { 
            
            if(CategoryDTO != null) {
                    var Category = new Category()
                    {
                        PkId = CategoryDTO.PkId,
                        Name = CategoryDTO.Name,
                        Description = CategoryDTO.Description
                    };

                    DbContext.Category.Update(Category);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Category Seccessflly Updated ";
                    ResponseDTO.StatusCode= 200;


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
        public async Task<ResponseDTO> DeleteCategory(int id)
        {
           var ResponseDTO=new ResponseDTO();
            try {
            var Data= await DbContext.Category.Where(x=> x.PkId==id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    DbContext.Category.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Category Seccessfully Deletetd";
                    ResponseDTO.StatusCode = 200;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            
            }
            catch (Exception ex) {
            ResponseDTO.ErrorMessage=ex.Message;
            }
            return ResponseDTO;
        }



    }
}
