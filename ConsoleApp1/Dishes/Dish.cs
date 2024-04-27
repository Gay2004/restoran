using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Dish
    {
        public string Name;
        public decimal Price;
        public decimal Mass;

        public Dish (string name, decimal price, decimal mass)
        {
            Name = name;
            Price = price;
            Mass = mass;
        }

    }
}
