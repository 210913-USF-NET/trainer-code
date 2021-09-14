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
                Console.WriteLine("[0] Manage Restaurants");
                Console.WriteLine("[1] Leave Reviews");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("You wanted to manage restos");
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
    }
}
