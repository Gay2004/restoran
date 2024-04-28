using ConsoleApp1.DISHES;
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

        public List<DishIngredient> Ingredients;

        public Dish(string name)
        {
            Name = name;
            Ingredients = new List<DishIngredient>();
        }

        public void AddIngredient(Product product,decimal quantity)
        {
                Ingredients.Add(new DishIngredient(product, quantity));
                Console.WriteLine($"Ingredient '{product.Name}' with quantity {quantity} added to the dish '{Name}'.");
        }
       

        public decimal CalculateCost()
        {
            decimal totalCost = 0;
            foreach (DishIngredient ingredient in Ingredients)
            {
                totalCost += ingredient.Product.Price * ingredient.QuantityUsed;
            }
            return totalCost;
        }

    }
}
