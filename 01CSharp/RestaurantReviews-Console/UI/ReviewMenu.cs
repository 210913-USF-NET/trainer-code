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
            if(allRestaurants == null || allRestaurants.Count == 0)
            {
                Console.WriteLine("No Restaurants :/");
                return;
            }
            for(int i = 0; i < allRestaurants.Count; i++)
            {
                Console.WriteLine($"[{i}] {allRestaurants[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            //pass by reference in, out, ref
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            //I'm checking to see that parse has been successful
            //and the result stays within the boundary of the index
            if(parseSuccess && parsedInput >= 0 && parsedInput < allRestaurants.Count)
            {
                Restaurant selectedRestaurant = allRestaurants[parsedInput];
                Console.WriteLine($"You picked {selectedRestaurant.Name}");

                Review reviewToAdd = new Review();
                rating:
                Console.WriteLine("Rating (1-5): ");
                int userRating;
                bool success = int.TryParse(Console.ReadLine(), out userRating);
                //if the parse has not been successful, as in the input was not a number
                if(!success) 
                {
                    //let the user know, and kick them back to try again
                    Console.WriteLine("Invalid input");
                    goto rating;
                }
                try
                {
                    //else, assign the number to rating
                    reviewToAdd.Rating = userRating;
                }
                catch (InputInvalidException e)
                {
                    //user entered integer out of bound
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //when do I use this block?
                    //to clean up a resource or finish my thought
                    //for example, Log.CloseAndFlush(); to close the logger 
                }
                //I'm done adding my rating
                Console.WriteLine("Notes: ");
                reviewToAdd.Note = Console.ReadLine();

                //I added the new review to the selected restaurant
                selectedRestaurant.Reviews.Add(reviewToAdd);

                //Implement this
                Restaurant updatedRestaurant = _bl.UpdateRestaurant(selectedRestaurant);

                Console.WriteLine("Review Added successfully");
                Console.WriteLine(updatedRestaurant);
                foreach(Review review in updatedRestaurant.Reviews)
                {
                    Console.WriteLine(review);
                }
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