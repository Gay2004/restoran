using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Schedule { get; set; }

        public Employee() {
        }


        public Employee(string name, decimal salary, string schedule)
        {
            Name = name;
            Salary = salary;
            Schedule = schedule;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} is working according to the schedule: {Schedule}");
        }
    }

    public class Chef : Employee
    {
        public Chef()
        {

        }
        public Chef(string name, decimal salary, string schedule) : base(name, salary, schedule)
        {
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is cooking delicious meals according to the schedule: {Schedule}");
        }
    }

    public class Waiter : Employee
    {
        public Waiter(string name, decimal salary, string schedule) : base(name, salary, schedule)
        {
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is serving customers according to the schedule: {Schedule}");
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, decimal salary, string schedule) : base(name, salary, schedule)
        {
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is managing the restaurant according to the schedule: {Schedule}");
        }
    }
}