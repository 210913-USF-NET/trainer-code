using System;
using Models;
using System.Collections.Generic;
using DL;

namespace RRBL
{
    public class BL : IBL
    {
        private IRepo _repo;
        
        //IRepo repo is the dependency of Business logic, that is being passed in aka "injected"
        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> allResto = _repo.GetAllRestaurants();
            foreach(Restaurant resto in allResto)
            {
                if (resto.Reviews.Count == 0) continue;
                int sum = 0;
                foreach(Review review in resto.Reviews)
                {
                    sum += review.Rating;
                }
                resto.Rating = sum / resto.Reviews.Count;
            }
            return allResto;
        }

        public Restaurant AddRestaurant(Restaurant resto)
        {
            return _repo.AddRestaurant(resto);
        }

        public Restaurant UpdateRestaurant(Restaurant restoToUpdate)
        {
            //add logic to update restaurant
            return _repo.UpdateRestaurant(restoToUpdate);
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            return _repo.SearchRestaurant(queryStr);
        }

        public Review AddAReview(Review review)
        {
            return _repo.AddAReview(review);
        }

        public Restaurant GetOneRestaurantById(int id)
        {
            return _repo.GetOneRestaurantById(id);
        }
    }
}
