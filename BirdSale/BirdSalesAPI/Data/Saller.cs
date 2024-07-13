using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BirdSalesAPI.Data
{
    public class Saller
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set;}
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
