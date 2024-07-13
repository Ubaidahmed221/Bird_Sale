using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface ISaller
    {
        public Task<ResponseDTO> GetSaller();
        public Task<ResponseDTO> AddSaller(SallerDTO SallerDTO);
        public Task<ResponseDTO> UpdateSaller(SallerDTO SallerDTO);
        public Task<ResponseDTO> DeleteSaller(int Id);
    }
}
