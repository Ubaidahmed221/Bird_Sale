using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface IContact
    {
        public Task<ResponseDTO> GetContact();
        public Task<ResponseDTO> AddContact(ContactDTO contactDTO);   
        public Task<ResponseDTO> UpdateContact(ContactDTO contactDTO);

        public Task<ResponseDTO> DeleteContact(int id);
    }
}
