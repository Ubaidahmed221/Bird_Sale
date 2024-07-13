using BirdSalesAPI.Data;
using BirdSalesAPI.DTOs;
using BirdSalesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Models
{
    public class ContactModel : IContact
    {
        private readonly ApplicationDbContext DbContext;
        public ContactModel(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }


        public async Task<ResponseDTO> GetContact()
        {
            var ResponseDTO = new ResponseDTO();
            try
            {
                ResponseDTO.Response = await DbContext.Contact.ToListAsync();
            }
            catch (Exception ex)
            {
                ResponseDTO.ErrorMessage = ex.Message;
            }
            return ResponseDTO;
        }

        public async Task<ResponseDTO> AddContact(ContactDTO contactDTO)
        {
            var ResponseDTO = new ResponseDTO();

            try
            {
                if (contactDTO != null)
                {
                    var Contact = new Contact()
                    {
                        name= contactDTO.name,
                        email= contactDTO.email,
                        phone= contactDTO.phone,
                        city= contactDTO.city,
                     
                    };

                    await DbContext.Contact.AddAsync(Contact);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Contact Successfully Added";
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

      

       
        public async Task<ResponseDTO> UpdateContact(ContactDTO contactDTO)
        {
            var ResponseDTO = new ResponseDTO();
            try
            {

                if (contactDTO != null)
                {
                    var Contact = new Contact()
                    {
                        id= contactDTO.id,
                       name = contactDTO.name,
                       email= contactDTO.email,
                       phone= contactDTO.phone,
                        city= contactDTO.city,
                    };

                    DbContext.Contact.Update(Contact);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Contact Seccessflly Updated ";
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
        public async Task<ResponseDTO> DeleteContact(int id)
        {

            var ResponseDTO = new ResponseDTO();
            try
            {
                var Data = await DbContext.Contact.Where(x => x.id == id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    DbContext.Contact.Remove(Data);
                    await DbContext.SaveChangesAsync();
                    ResponseDTO.Response = "Contact Seccessfully Deletetd";
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
    }
}
