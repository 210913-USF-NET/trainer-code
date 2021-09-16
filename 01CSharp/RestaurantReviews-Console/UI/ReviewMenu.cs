using System;
using RRBL;

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
            Console.WriteLine("Select a restaurant to write a review for");
            //I need a list of all restaurant to select from
        }
    }
}