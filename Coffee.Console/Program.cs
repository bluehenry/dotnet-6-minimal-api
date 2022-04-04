using System;
using System.Linq;
using CoffeeApp.Data;
using CoffeeApp.Domain;

namespace CoffeeApp.UI
{
    class Program
    {
        private static CoffeeContext _context = new CoffeeContext();

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetCoffees("Before Add:");
            AddCoffee();
            GetCoffees("After Add:");
            Console.Write("Press any Key...");
            Console.ReadKey();
        }

        private static void AddCoffee()
        {
            var coffees = new Coffee { Name = "Long Black" };
            _context.Coffees.Add(coffees);
            _context.SaveChanges();
        }

        private static void GetCoffees(string text)
        {
            var coffees = _context.Coffees.ToList();
            Console.WriteLine($"{text}: Coffee count is {coffees.Count}");
            foreach (var coffe in coffees)
            {
                Console.WriteLine(coffe.Name);
            }
        }
    }
}