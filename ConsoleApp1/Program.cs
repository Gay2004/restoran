using ConsoleApp1.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService  productService = new ProductService();
            productService.AddProduct("BEEF", ProductType.Meat, 500, 500);
            productService.AddProduct("Carrot", ProductType.Vegetable, 25, 125);
            productService.AddProduct("Apple", ProductType.Fruit, 10, 150);
            productService.AddProduct("Pepper", ProductType.Spice, 25, 200);

            productService.DisplayProducts();
            productService.RemoveProduct("Apple");
            productService.DisplayProducts();






        }
    }
}