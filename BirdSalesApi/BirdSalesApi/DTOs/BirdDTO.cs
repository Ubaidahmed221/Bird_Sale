namespace BirdSalesAPI.DTOs
{
    public class BirdDTO
    {
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public IFormFile ImageURL { get; set; }
        public int FKCategoryId { get; set; }
    }
}
