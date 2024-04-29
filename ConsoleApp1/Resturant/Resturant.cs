using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Restaurant
    {
        public string Name { get; set; }
        public Chef Chef { get; set; }
        public List<Employee> Employees { get; private set; }
        public List<Dish> Menu { get; private set; }

        public Restaurant() { }

        public Restaurant(string name, Chef chef)
        {
            Name = name;
            Chef = chef;
            Employees = new List<Employee>();
            Menu = new List<Dish>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public void AddDish(Dish dish)
        {
            Menu.Add(dish);
        }

        public void RemoveDish(Dish dish)
        {
            Menu.Remove(dish);
        }
    }
}
