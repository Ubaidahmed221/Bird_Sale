using System.ComponentModel.DataAnnotations;

namespace BirdSalesAPI.Data
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }


    }
}
