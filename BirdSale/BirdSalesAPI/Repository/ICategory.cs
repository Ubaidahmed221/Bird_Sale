using BirdSalesAPI.DTOs;

namespace BirdSalesAPI.Repository
{
    public interface ICategory
    {
        public Task<ResponseDTO> GetCategory();
        public Task<ResponseDTO> AddCategory(CategoryDTO categoryDTO);
        public Task<ResponseDTO> UpdateCategory(CategoryDTO categoryDTO);
        public Task<ResponseDTO> DeleteCategory(int id);
    }
}
