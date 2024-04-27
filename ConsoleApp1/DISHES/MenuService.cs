using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MenuService
    {
        private List<Dish> dishes;
        
        public MenuService()
        {
            dishes = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }

        public void RemoveDish(string dishName)
        {
            Dish dish = dishes.FirstOrDefault(d => d.Name == dishName);
            if (dish != null)
            {
                dishes.Remove(dish);
            }
            else
            {
                Console.WriteLine("Dish not found");
            }
        }


        public void DisplayDishes()
        {   
            foreach (Dish dish in dishes)
            {
                Console.WriteLine($"Dish: {dish.Name}");
                foreach (Product  ingredient in dish.Ingredients)
                {
                    Console.WriteLine($"Ingredient - {ingredient.Name},Quantity: {ingredient.Quantity},Total Price: {ingredient.Price}");
                }
                Console.WriteLine();

            }
        }

        public void AddIngredientToDish(string dishName, Product product, decimal quantity)
        {
            Dish dish = dishes.Find(d => d.Name == dishName);
            if (dish != null)
            {
                dish.AddIngredient(product, quantity);
                decimal totalCost = dish.CalculateCost();
            }
            else
            {
                Console.WriteLine("Dish not found");
            }
        }

    }
}
