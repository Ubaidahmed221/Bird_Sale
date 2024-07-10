using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class BirdModel : IBird
    {
        private readonly ApplicationDbContext DbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BirdModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.DbContext = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseDTO> GetBird()
        {
            var responseDTO = new ResponseDTO();
            try
            {
                responseDTO.Response = await DbContext.Birds.ToListAsync();
            }
            catch (Exception ex)
            {
                responseDTO.ErrorMessage = ex.Message;
            }
            return responseDTO;
        }
        public async Task<ResponseDTO> AddBird(BirdDTO birdDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var path = "";
                if(birdDTO.ImageURL != null)
                {
                    var FileName = birdDTO.ImageURL.FileName;
                    path = Path.Combine("Uploads",webHostEnvironment.WebRootPath+FileName);
                    using(Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await birdDTO.ImageURL.CopyToAsync(stream);
                    }
                }
                if(birdDTO != null)
                {
                var Bird = new Bird()
                {
                    Name = birdDTO.Name,
                    Species = birdDTO.Species,
                    Age = birdDTO.Age,
                    Price = birdDTO.Price,
                    Description = birdDTO.Description,
                    ImageURL = path,
                    FKCategoryId = birdDTO.FKCategoryId
                };

               await DbContext.Birds.AddAsync(Bird);
               await DbContext.SaveChangesAsync();
               ResponseDTO.Response = "Bird Add Successfully";
               ResponseDTO.StatusCode = 200;
               }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }

            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
        public async Task<ResponseDTO> UpdateBird(BirdDTO birdDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Birds.Where(x => x.PkId == birdDTO.PkId).FirstOrDefaultAsync();
                if(Data != null)
                {
                    if(birdDTO.ImageURL != null)
                    {
                        var filename = birdDTO.ImageURL.FileName;
                        var path = filename = Data.ImageURL;
                        var removeimagepath = path.Remove(0, 8);
                        var pathc = Path.Combine("Uploads", webHostEnvironment.WebRootPath + removeimagepath);
                        using(Stream stream = new FileStream(path,FileMode.Create))
                        {
                            await birdDTO.ImageURL.CopyToAsync(stream);
                        }
                    }
                }

                if(birdDTO != null)    
                {
                    var Bird = new Bird()
                    {
                        PkId = birdDTO.PkId,
                        Name = birdDTO.Name,
                        Species = birdDTO.Species,
                        Age = birdDTO.Age,
                        Price = birdDTO.Price,
                        Description = birdDTO.Description,
                        FKCategoryId = birdDTO.FKCategoryId
                    };

                    DbContext.Birds.Update(Bird);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Bird Update Successfully";
                    ResponseDTO.StatusCode = 200;
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }
        public async Task<ResponseDTO> DeleteBird(int Id)
        {
            var responseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Birds.Where(x => x.PkId == Id).FirstOrDefaultAsync();
                var wwwpath = webHostEnvironment.WebRootPath;
                var filename = Data.ImageURL;
                var path = Path.Combine(wwwpath + filename);
                if(File.Exists(path))
                {
                    File.Delete(path);
                if (Data != null)
                {
                    DbContext.Birds.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    responseDTO.Response = "Bird Delete Successfully";
                    responseDTO.StatusCode = 200;
                }
                else
                {
                    responseDTO.StatusCode = 404;
                }
                }
                else
                {
                    responseDTO.ErrorMessage = "Image Not Found";
                }
            }
            catch(Exception ex)
            {
                responseDTO.ErrorMessage = ex.Message;
            }
            return responseDTO;
        }

    }
}
