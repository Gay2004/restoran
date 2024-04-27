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

        public  List<Product> Ingredients = new List<Product>();

        public Dish(string name)
        {
            Name = name;
            Ingredients = new List<Product>();
        }

        public void AddIngredient(Product product, decimal quantity)
        {
            Ingredients.Add(new Product(product.Name,product.Type, quantity,product.Price));
        }

        public decimal CalculateCost()
        {
            decimal totalCost = 0;
            foreach (Product ingredient in Ingredients)
            {
                totalCost += ingredient.Price * ingredient.Quantity;
            }
            return totalCost;
        }

    }
}
