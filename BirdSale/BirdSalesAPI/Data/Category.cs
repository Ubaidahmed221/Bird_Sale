using System.ComponentModel.DataAnnotations;

namespace BirdSalesAPI.Data
{
    public class Category       
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
