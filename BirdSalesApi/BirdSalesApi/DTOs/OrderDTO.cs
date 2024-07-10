using System.ComponentModel.DataAnnotations.Schema;

namespace BirdSalesAPI.DTOs
{
    public class OrderDTO
    {
        public int PkId { get; set; }
        public int FkCustomerId { get; set; }
        public int FkBirdId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string TotelPrice { get; set; }
    }
}
