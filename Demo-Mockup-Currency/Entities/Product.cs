using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Demo_Mockup_Currency.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
