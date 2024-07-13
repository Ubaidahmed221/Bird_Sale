using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface IBird
    {
        public Task<ResponseDTO> GetBird();
        public Task<ResponseDTO> AddBird(BirdDTO birdDTO0);
        public Task<ResponseDTO> UpdateBird(BirdDTO birdDTO0);
        public Task<ResponseDTO> DeleteBird(int Id);
    }

}
