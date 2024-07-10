using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdSalesAPI.Data
{
    public class Bird
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        [ForeignKey("Category")]
        public int FKCategoryId { get; set; }
        public Category Category { get; set; }

    }
}
