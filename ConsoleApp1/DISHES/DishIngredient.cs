using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DISHES
{
    public class DishIngredient
    {
        public Product Product;
        public decimal QuantityUsed;

        public DishIngredient(Product product, decimal quantityUsed)
        {
            Product = product;
            QuantityUsed = quantityUsed;
        }
    }
}
