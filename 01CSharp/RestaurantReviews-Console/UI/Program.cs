using System;
using Models;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("Welcome to Restaurant Reviews!");
                Console.WriteLine("[0] Create Restaurant");
                Console.WriteLine("[1] Leave Reviews");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        CreateRestaurant();
                        break;

                    case "1":
                        Console.WriteLine("you wanted to leave reviews");
                        break;

                    case "x":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("I don't know what you're talking about");
                        break;
                }
            } while (!exit);
        }

        private void CreateRestaurant()
        {
            Console.WriteLine("Creating new restaurant");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("State: ");
            string state = Console.ReadLine();

            Restaurant newResto = new Restaurant(name, city, state);

            Console.WriteLine($"You created {newResto.ToString()}");
        }
    }
}
