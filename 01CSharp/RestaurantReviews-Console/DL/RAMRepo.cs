using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace DL
{
    //implement IRepo using singleton design pattern
    public sealed class RAMRepo : IRepo
    {
        //private instance. No one has access to it other than me
        private static RAMRepo _instance;

        //I hid this constructor, so no one can access it other than me
        //and create multiple instances of this class
        private RAMRepo()
        {
            //I'm lazily instantiating the restaurants list
            //it's not a thing until an/the instance of RAMRepo is a thing
            _restaurants = new List<Restaurant>()
            {
                //I'm seeding this restaurant list with this sample resto
                //so I can test quicker
                new Restaurant()
                {
                    Name = "Salt and Straw",
                    City = "Portland",
                    State = "OR"
                }
            };
        }

        //this is the public get instance method I expose to the users
        //they can't directly instantiate this class
        //if they want an instance of this singleton class
        //they have to call this GetInstance method
        public static RAMRepo GetInstance()
        {
            //if there is no instance available,
            if(_instance == null)
            {
                //create a new instance
                _instance = new RAMRepo();
            }
            //return the instance to the end user
            return _instance;
        }

        //this is my restaurant collection
        //where I'll be storing all my restos!
        private static List<Restaurant> _restaurants;

        //this is a type of setter for restaurants
        public Restaurant AddRestaurant(Restaurant resto)
        {
            _restaurants.Add(resto);
            return resto;
        }

        //this is a getter for _restaurants
        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurants;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurantToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
