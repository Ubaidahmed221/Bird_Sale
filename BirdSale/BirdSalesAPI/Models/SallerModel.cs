using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class SallesModel : ISaller
    {
        private readonly ApplicationDbContext DbContext;
        public SallesModel(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public async Task<ResponseDTO> GetSaller()  
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
              ResponseDTO.Response = await DbContext.Sallers.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
             return ResponseDTO;
        }
        public async Task<ResponseDTO> AddSaller(SallerDTO SallerDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try 
            {
                if (SallerDTO != null)
                {
                var Saller = new Saller()
                {
                    Name = SallerDTO.Name,
                    Address = SallerDTO.Address,
                    ContactNumber = SallerDTO.ContactNumber,
                };
                await DbContext.Sallers.AddAsync(Saller);
                await DbContext.SaveChangesAsync();
                ResponseDTO.Response = "Saller Add Successfully";
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
        public async Task<ResponseDTO> UpdateSaller(SallerDTO SallerDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                if (SallerDTO != null)
                {
                var Saller = new Saller()
                {
                    PkId = SallerDTO.PkId,
                    Name = SallerDTO.Name,
                    Address = SallerDTO.Address,
                    ContactNumber = SallerDTO.ContactNumber,
                };
                    DbContext.Sallers.Update(Saller);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Saller Update Successfully";
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
        public async Task<ResponseDTO> DeleteSaller(int Id)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Sallers.Where(x => x.PkId == Id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    DbContext.Sallers.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Saller Deleted";
                }
                else
                {
                    ResponseDTO.StatusCode = 404;
                }
            }
            catch(Exception ex)
            {
                ResponseDTO.ErrorMessage= ex.Message;
            }
            return ResponseDTO;
        }


    }
}
