using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BirdSalesAPI.Data
{
    public class Order
    {

        [Key]
        public int PkId { get; set; }
        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Bird")]
        public int FkBirdId { get; set; }
        public Bird Bird { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string TotelPrice { get; set; }
       
       
    }
}
