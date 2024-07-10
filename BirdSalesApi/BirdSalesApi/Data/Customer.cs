﻿using System.ComponentModel.DataAnnotations;

namespace BirdSalesAPI.Data
{
    public class Customer
    {
        [Key]
        public int PkId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address {  get; set; }
    }
}
