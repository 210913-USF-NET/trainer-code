using System;
using RRBL;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        private IBL _bl;

        public ReviewMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("This is review menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Write a review");
                Console.WriteLine("[x] Go Back To Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        WriteAReview();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("What are you talking about");
                        break;
                }
            } while(!exit);
        }

        private void WriteAReview()
        {
            //this is a region
            reviewStart:
            Console.WriteLine("Select a restaurant to write a review for");
            List<Restaurant> allRestaurants = _bl.GetAllRestaurants();
            for(int i = 0; i < allRestaurants.Count; i++)
            {
                Console.WriteLine($"[{i}] {allRestaurants[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            //pass by reference in, out, ref
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess)
            {
                Restaurant selectedRestaurant = allRestaurants[parsedInput];
            }
            else
            {
                Console.WriteLine("invalid input");
                //this is how we go to a region
                goto reviewStart;
            }
        }
    }
}