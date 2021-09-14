using System;
using System.Linq;
using System.Collections.Generic;

namespace DL
{
    //implement IRepo using singleton design pattern
    public sealed class RAMRepo : IRepo
    {
        private static RAMRepo _instance;

        private RAMRepo()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name: "Salt and Straw",
                    City: "Portland",
                    State: "OR"
                }
            }
        }

        public static RAMRepo GetInstance()
        {
            if(_instance == null)
            {
                _instance = new RAMRepo();
            }
            return _instance;
        }

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
    }
}
