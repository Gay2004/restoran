using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name;
        public ProductType Type;
        public decimal Quantity;
        public decimal Price;
        public Product(string name,ProductType type, decimal quantity,decimal price)
        {
            Name = name;
            Type = type;
            Quantity = quantity;
            Price = price;
        }

    }
  
}
