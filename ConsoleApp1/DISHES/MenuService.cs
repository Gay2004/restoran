using ConsoleApp1.DISHES;
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
            if (dishes.Count == 0)
            {
                Console.WriteLine("No dishes available.");
                return;
            }

            Console.WriteLine("Menu:");

            List<Dish> sortedDishes = dishes.OrderBy(dish => dish.CalculateCost()).ToList();

            foreach (Dish dish in sortedDishes)
            {
                Console.WriteLine($"Dish: {dish.Name}");

                foreach (DishIngredient ingredient in dish.Ingredients)
                {
                    Console.WriteLine($" Ingredient: {ingredient.Product.Name}, Quantity: {ingredient.QuantityUsed}");
                    Console.Write("");
                }
                Console.WriteLine($"Total cost: {dish.CalculateCost()}");
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

        public Dish GetDishByName(string dishName)
        {
            return dishes.FirstOrDefault(d => d.Name == dishName);
        }

    }
}
